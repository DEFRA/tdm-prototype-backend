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
        public async Task<MatchResult> MatchNotification(string documentReference)
        {
            var referenceNumber = MatchingReferenceNumber.FromCds(documentReference);


            var builder = Builders<Notification>.Filter;

            var filter = builder.Eq(x => x.ReferenceNumber, referenceNumber.AsIpaffsReference())
                         & builder.Eq(x => x.Movement.Matched, false);

            var setFieldDefinitions =
                new SetFieldDefinitionsBuilder<Notification>().Set(x => x.Movement,
                    new MatchingStatus() {
                        AdditionalInformation =
                        [
                            new("matchingLevel", "1")
                        ],
                        Matched = true,
                        Reference = documentReference
                    });


            var pipeline = new EmptyPipelineDefinition<Notification>()
                .Match(filter)
                .Set(setFieldDefinitions);

            
            var items = await notificationService.Pipeline(pipeline);

            foreach (var notification in items)
            {
                await notificationService.Upsert(notification);
                await MatchCds(notification.ReferenceNumber);
            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> MatchCds(string notificationId)
        {
            //var notification = await notificationService.Find(notificationId);
            var referenceNumber = MatchingReferenceNumber.FromIpaffs(notificationId);


            var builder = Builders<Movement>.Filter;

            var documentReferenceFieldDefinition = new StringFieldDefinition<Movement, string>(
                $"{nameof(Movement.Items)}.{nameof(Items.Documents)}.{nameof(Document.DocumentReference)}");

            var filter = builder.Eq(documentReferenceFieldDefinition, referenceNumber.AsCdsDocumentReference())
                         & builder.Eq(x => x.Notification.Matched, false);

            var setFieldDefinitions =
                new SetFieldDefinitionsBuilder<Movement>().Set(x => x.Notification,
                    new MatchingStatus()
                    {
                        AdditionalInformation =
                        [
                            new("matchingLevel", "1")
                        ],
                        Matched = true,
                        Reference = notificationId
                    });


            var pipeline = new EmptyPipelineDefinition<Movement>()
                .Match(filter)
                .Set(setFieldDefinitions);


            var items = await movementService.Pipeline(pipeline);

            foreach (var movement in items)
            {
                await movementService.Upsert(movement);
                await MatchNotification(referenceNumber.AsCdsDocumentReference());
            }

            return new MatchResult(items.Any());
        }


        public async Task<MatchResult> Match(MatchingReferenceNumber matchingReferenceNumber)
        {
            var cdsResult = await MatchCds(matchingReferenceNumber.AsIpaffsReference());
            var notificationResult = await MatchNotification(matchingReferenceNumber.AsCdsDocumentReference());

            return new MatchResult(cdsResult.Matched || notificationResult.Matched);
        }
    }
}
