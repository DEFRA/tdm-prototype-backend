using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using RelationshipLinks = TdmPrototypeBackend.Types.RelationshipLinks;

namespace TdmPrototypeBackend.Matching
{
    public class MatchingService(
        MatchingStorageService<Notification> notificationService,
        MatchingStorageService<Movement> movementService) : IMatchingService
    {
        public async Task<MatchResult> MatchNotification(int matchReference)
        {
            var movements = await movementService.Filter(Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [matchReference]));
            var movement = movements.SingleOrDefault();
            if (movement == null) return new MatchResult(false);
           
            var builder = Builders<Notification>.Filter;
            var filter = builder.Eq(x => x._MatchReference, matchReference);
            var items = await notificationService.Filter(filter);

            foreach (var notification in items)
            {
                var doc = (from item in movement.Items
                    from itemDocument in item.Documents
                    where itemDocument.DocumentReference.Contains(matchReference.ToString())
                    select itemDocument).FirstOrDefault();

                var referenceNumber = MatchingReferenceNumber.FromCds(doc.DocumentReference, doc.DocumentCode);

                if (notification.IpaffsType != referenceNumber.ChedType)
                {
                    notification.AddRelationship("movements", new TdmRelationshipObject
                    {
                        Matched = false,
                        Links = RelationshipLinks.CreateForNotification(notification),
                        Data = [RelationshipDataItem.CreateFromMovement(notification, movement, matchReference.ToString(), false, "ChedType does not match")]
                    });
                }
                else
                {
                    notification.AddRelationship("movements", new TdmRelationshipObject
                    {
                        Matched = true,
                        Links = RelationshipLinks.CreateForNotification(notification),
                        Data = [RelationshipDataItem.CreateFromMovement(notification, movement, matchReference.ToString())]
                    });
                }

                var auditEntry = AuditEntry.CreateMatch(movement.Id, notification.Version.GetValueOrDefault(),
                    notification.LastUpdated,
                    notification.LastUpdatedBy?.DisplayName);
                notification.Update(auditEntry);
                await notificationService.Upsert(notification);
            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> MatchCds(int matchReference)
        {
            var notifications = await notificationService.Filter(Builders<Notification>.Filter.Eq(x => x._MatchReference, matchReference));
            var notification = notifications.FirstOrDefault();
            if (notification == null) return new MatchResult(false);

            var filter = Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [matchReference]);
            var items = await movementService.Filter(filter);

            foreach (var movement in items)
            {
                var doc = (from item in movement.Items
                    from itemDocument in item.Documents
                    where itemDocument.DocumentReference.Contains(matchReference.ToString())
                    select itemDocument).FirstOrDefault();

                var referenceNumber = MatchingReferenceNumber.FromCds(doc.DocumentReference, doc.DocumentCode);
                if (notification.IpaffsType != referenceNumber.ChedType)
                {
                    movement.AddRelationship("notifications", new TdmRelationshipObject
                    {
                        Matched = false,
                        Links = RelationshipLinks.CreateForMovement(movement),
                        Data = [RelationshipDataItem.CreateFromNotification(notification,  movement, matchReference.ToString(),false, "ChedType does not match")],
                    });
                }
                else
                {
                    movement.AddRelationship("notifications", new TdmRelationshipObject
                    {
                        Matched = true,
                        Links = RelationshipLinks.CreateForMovement(movement),
                        Data = [RelationshipDataItem.CreateFromNotification(notification, movement, matchReference.ToString())]
                    });
                }

                var auditEntry = AuditEntry.CreateMatch(notification.Id, 
                    movement.ClearanceRequests.First().Header.EntryVersionNumber.GetValueOrDefault(),
                    movement.LastUpdated,
                    movement.ClearanceRequests.First().Header.DeclarantName);
                movement.Update(auditEntry);
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
