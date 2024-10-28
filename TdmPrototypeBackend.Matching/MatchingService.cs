using MediatR;
using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using RelationshipLinks = TdmPrototypeBackend.Types.RelationshipLinks;

namespace TdmPrototypeBackend.Matching
{
    public class MatchingService(
        MatchingStorageService<Notification> notificationService,
        MatchingStorageService<Movement> movementService,
        IMediator mediator) : IMatchingService
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
                    notification.LastUpdated);
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
            var movements = await movementService.Filter(filter);
            
            var model = new MatchModel
            {
                MatchReference = matchReference.ToString(), Movements = movements, Notifications = notifications
            };

            return await Match(model);
        }
        
        public async Task<MatchResult> Match(MatchModel matchModel)
        {
            return await mediator.Send(new MatchRequest(matchModel));
        }

        public async Task<MatchResult> Match(MatchingReferenceNumber matchingReferenceNumber)
        {
            var cdsResult = await MatchCds(matchingReferenceNumber.Identifier);
            var notificationResult = await MatchNotification(matchingReferenceNumber.Identifier);

            return new MatchResult(cdsResult.Matched || notificationResult.Matched);
        }
    }
}
