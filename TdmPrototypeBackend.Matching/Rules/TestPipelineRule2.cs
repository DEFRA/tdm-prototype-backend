using MongoDB.Driver;
using TdmPrototypeBackend.Matching.Pipelines;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Matching.Rules;

public class TestPipelineRule2 : TestPipelineBase
{
    public override async Task<MatchResult> ProcessMatch(MatchModel model)
    {
        if (model.Notifications.Any() != true || model.Movements.Any() != true)
        {
            return new MatchResult(false);
        }
        
        // fix for multi-ched
        var notification = model.Notifications.FirstOrDefault();
        var movements = model.Movements;

        foreach (var movement in movements)
        {
            var commodityGroups = movement.Items
                .Where(i => i.Documents != null && i.Documents.Any())
                .GroupBy(i => i.TaricCommodityCode)
                .Select(g => new { Code = g.Key, TotalMass = g.Sum(v => v.ItemNetMass) });



            var docs = (from item in movement.Items
                        from itemDocument in item.Documents
                        where itemDocument.DocumentReference.Contains(model.MatchReference)
                        select itemDocument).ToList();

            foreach (var doc in docs)
            {

                var referenceNumber = MatchingReferenceNumber.FromCds(doc.DocumentReference, doc.DocumentCode);
                if (notification.IpaffsType != referenceNumber.ChedType)
                {
                    movement.AddRelationship("notifications", new TdmRelationshipObject
                    {
                        Matched = false,
                        Links = RelationshipLinks.CreateForMovement(movement),
                        Data = [RelationshipDataItem.CreateFromNotification(notification, movement, model.MatchReference, false, "ChedType does not match")],
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
                            RelationshipDataItem.CreateFromNotification(notification, movement,
                                model.MatchReference)
                        ]
                    };
                    movement.AddRelationship("notifications", rel);
                }

                var auditEntry = AuditEntry.CreateMatch(
                    notification.Id,
                    movement.ClearanceRequests.First().Header.EntryVersionNumber.GetValueOrDefault(),
                    movement.LastUpdated);
                movement.Update(auditEntry);
            }

            // save in post-processing
            //await movementService.Upsert(movement);
        }
        
        // debug
        model.Record += "Did rule two" + Environment.NewLine;

        return new MatchResult(false);
    }
}