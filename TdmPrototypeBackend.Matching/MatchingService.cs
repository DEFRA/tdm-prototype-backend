using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Matching
{
    public class MatchingService(
        MatchingStorageService<Notification> notificationService,
        MatchingStorageService<Movement> movementService) : IMatchingService
    {
        public async Task<MatchResult> MatchNotification(int matchReference)
        {
            var movements =
                await movementService.Filter(Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [matchReference]));
            var movement = movements.FirstOrDefault();

            if (movement == null)
            {
                return new MatchResult(false);
            }
           
            
           
            var builder = Builders<Notification>.Filter;

            var filter = builder.Eq(x => x._MatchReference, matchReference);

            
            var items = await notificationService.Filter(filter);

            foreach (var notification in items)
            {
                if (!notification.Movements.Any(x => x.Reference == movement.Id))
                {
                    var doc = (from item in movement.Items
                        from itemDocument in item.Documents
                        where itemDocument.DocumentReference.Contains(matchReference.ToString())
                        select itemDocument).FirstOrDefault();


                    var referenceNumber = MatchingReferenceNumber.FromCds(doc.DocumentReference, doc.DocumentCode);

                    notification.Movements.RemoveAll(x => !x.Matched);
                    if (notification.IpaffsType != referenceNumber.ChedType)
                    {
                        notification.Movements.Add(new MatchingStatus()
                        {
                            AdditionalInformation =
                            [
                                new("matchingLevel", "1"),
                                new("reason", "ChedType does not match")
                            ],
                            Matched = false,
                            Reference = movement.Id,
                            Item = movement.Items
                                .FirstOrDefault(x => x.Documents.Any(d => d.DocumentReference.Contains(matchReference.ToString())))
                                ?.ItemNumber.ToString()
                        });
                    }
                    else
                    {
                        notification.Movements.Add(new MatchingStatus()
                        {
                            AdditionalInformation =
                            [
                                new("matchingLevel", "1")
                            ],
                            Matched = true,
                            Reference = movement.Id,
                            Item = movement.Items
                                .FirstOrDefault(x => x.Documents.Any(d => d.DocumentReference.Contains(matchReference.ToString())))
                                ?.ItemNumber.ToString()
                        });
                    }

                    
                  
                    await notificationService.Upsert(notification);
                }

            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> MatchCds(int matchReference)
        {
            var notifications =
                await notificationService.Filter(Builders<Notification>.Filter.Eq(x => x._MatchReference,
                    matchReference));
                var notification = notifications.FirstOrDefault();

                if (notification == null)
                {
                    return new MatchResult(false);
                }

            var filter = Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [matchReference]);

            var items = await movementService.Filter(filter);

            foreach (var movement in items)
            {
                movement.Notifications.RemoveAll(x => !x.Matched);
                movement.Notifications.Add(new MatchingStatus() {
                    AdditionalInformation =
                    [
                        new("matchingLevel", "1")
                    ],
                    Matched = true,
                    Reference = notification.Id,
                    Item = notification.PartOne?.Commodities?.CommodityComplements?.FirstOrDefault()?.CommodityID 
                });
                await movementService.Upsert(movement);
            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> Match(MatchingReferenceNumber matchingReferenceNumber)
        {
            var cdsResult = await MatchCds(matchingReferenceNumber.Identifier);
            var notificationResult = await MatchNotification(matchingReferenceNumber.Identifier);

            return new MatchResult(cdsResult.Matched || notificationResult.Matched);
        }
    }
}
