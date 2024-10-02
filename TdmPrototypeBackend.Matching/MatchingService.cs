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
        public async Task<MatchResult> MatchNotification(string matchReference)
        {
            var movements =
                await movementService.Filter(Builders<Movement>.Filter.AnyStringIn(x => x._MatchReferences, matchReference));
            var movement = movements.FirstOrDefault();
           
            
           
            var builder = Builders<Notification>.Filter;

            var filter = builder.Regex(x => x._MatchReference, matchReference);

            
            var items = await notificationService.Filter(filter);

            foreach (var notification in items)
            {
                if (!notification.Movements.Any(x => x.Reference == movement.Id))
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
                            .FirstOrDefault(x => x.Documents.Any(d => d.DocumentReference.Contains(matchReference)))
                            ?.ItemNumber.ToString()
                    });
                    await notificationService.Upsert(notification);
                }

                await MatchCds(notification.ReferenceNumber);
            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> MatchCds(string matchReference)
        {
            var notifications =
                await notificationService.Filter(Builders<Notification>.Filter.Eq(x => x._MatchReference,
                    matchReference));
                var notification = notifications.FirstOrDefault();

            var filter = Builders<Movement>.Filter.AnyStringIn(x => x._MatchReferences, matchReference);

            var items = await movementService.Filter(filter);

            foreach (var movement in items)
            {
                movement.Notifications.Add(new MatchingStatus() {
                    AdditionalInformation =
                    [
                        new("matchingLevel", "1")
                    ],
                    Matched = true,
                    Reference = notification.Id,
                    Item = notification.PartOne?.Commodities?.CommodityComplements?.FirstOrDefault()?.UniqueComplementID 
                });
                await movementService.Upsert(movement);
                await MatchNotification(matchReference);
            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> Match(MatchingReferenceNumber matchingReferenceNumber)
        {
            var cdsResult = await MatchCds(matchingReferenceNumber.AsYearIdentifier());
            var notificationResult = await MatchNotification(matchingReferenceNumber.AsYearIdentifier());

            return new MatchResult(cdsResult.Matched || notificationResult.Matched);
        }
    }
}
