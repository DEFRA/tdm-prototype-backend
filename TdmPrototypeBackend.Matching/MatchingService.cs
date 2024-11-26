using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using RelationshipLinks = TdmPrototypeBackend.Types.RelationshipLinks;

namespace TdmPrototypeBackend.Matching
{
    public class MatchingService : IMatchingService
    {
        private readonly MatchingStorageService<Notification> _notificationService;
        private readonly MatchingStorageService<Movement> _movementService;

        public MatchingService(MatchingStorageService<Notification> notificationService, MatchingStorageService<Movement> movementService)
        {
            _notificationService = notificationService;
            _movementService = movementService;
            
            _notificationService.DefineIndexesIfNotPresent(_notificationService.IndexBuilder.Ascending(x => x._MatchReference));
            _movementService.DefineIndexesIfNotPresent(_movementService.IndexBuilder.Ascending(x => x._MatchReferences));
        }

        public async Task<MatchResult> MatchNotification(int matchReference)
        {
            var movements = await _movementService.Filter(Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [matchReference]));
            var movement = movements.FirstOrDefault();
            if (movement == null) return new MatchResult(false);
           
            var builder = Builders<Notification>.Filter;
            var notifications = await _notificationService.Filter(builder.Eq(x => x._MatchReference, matchReference));

            foreach (var notification in notifications)
            {
                notification.ClearRelationships();
                
                var docs = (from item in movement.Items
                    from itemDocument in item.Documents
                    where itemDocument.DocumentReference.Contains(matchReference.ToString())
                    select new { Item = item, ItemDocument = itemDocument}).ToList();

                foreach (var doc in docs)
                {
                    var referenceNumber = MatchingReferenceNumber.FromCds(doc.ItemDocument.DocumentReference, doc.ItemDocument.DocumentCode);

                    if (notification.IpaffsType != referenceNumber.ChedType)
                    {
                        notification.AddRelationship(new TdmRelationshipObject
                        {
                            Matched = false,
                            Links = RelationshipLinks.CreateForNotification(notification),
                            Data = [RelationshipDataItem.CreateFromMovement(movement, doc.Item, matchReference.ToString(), false, "ChedType does not match")]
                        });
                    }
                    else
                    {
                        notification.AddRelationship(new TdmRelationshipObject
                        {
                            Matched = true,
                            Links = RelationshipLinks.CreateForNotification(notification),
                            Data = [RelationshipDataItem.CreateFromMovement(movement, doc.Item, matchReference.ToString())]
                        });
                    }
                }

                var auditEntry = AuditEntry.CreateMatch(movement.Id, notification.Version.GetValueOrDefault(), notification.LastUpdated);
                notification.Update(auditEntry);

                await _notificationService.Upsert(notification);
            }

            return new MatchResult(notifications.All(x => x.Relationships.Movements.Matched));
        }


        public async Task<MatchResult> MatchCds(int matchReference)
        {
            var notifications = await _notificationService.Filter(Builders<Notification>.Filter.Eq(x => x._MatchReference, matchReference));
            var notification = notifications.FirstOrDefault();
            if (notification == null) return new MatchResult(false);

            var filter = Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [matchReference]);
            var movements = await _movementService.Filter(filter);

            foreach (var movement in movements)
            {
                movement.ClearRelationships();
                
                var docs = (from item in movement.Items
                    from itemDocument in item.Documents
                    where itemDocument.DocumentReference.Contains(matchReference.ToString())
                    select new { Item = item, ItemDocument = itemDocument}).ToList();
                
                foreach (var doc in docs)
                {
                    
                    var referenceNumber = MatchingReferenceNumber.FromCds(doc.ItemDocument.DocumentReference, doc.ItemDocument.DocumentCode);
                    if (notification.IpaffsType != referenceNumber.ChedType)
                    {
                        movement.AddRelationship(new TdmRelationshipObject
                        {
                            Matched = false,
                            Links = RelationshipLinks.CreateForMovement(movement),
                            Data = [RelationshipDataItem.CreateFromNotification(notification, doc.Item, false, "ChedType does not match")],
                        });
                    }
                    else
                    {
                        var rel = new TdmRelationshipObject
                        {
                            Matched = true,
                            Links = RelationshipLinks.CreateForMovement(movement),
                            Data =
                            [
                                RelationshipDataItem.CreateFromNotification(notification, doc.Item)
                            ]
                        };
                        movement.AddRelationship(rel);
                    }
                }
                
                var auditEntry = AuditEntry.CreateMatch(notification.Id, movement.ClearanceRequests.First().Header.EntryVersionNumber.GetValueOrDefault(), movement.LastUpdated);
                movement.Update(auditEntry);

                await _movementService.Upsert(movement);
            }

            return new MatchResult(movements.All(x => x.Relationships.Notifications.Matched));
        }


        public async Task<MatchResult> Match(MatchingReferenceNumber matchingReferenceNumber)
        {
            var cdsResult = await MatchCds(matchingReferenceNumber.Identifier);
            var notificationResult = await MatchNotification(matchingReferenceNumber.Identifier);

            return new MatchResult(cdsResult.Matched || notificationResult.Matched);
        }
    }
}
