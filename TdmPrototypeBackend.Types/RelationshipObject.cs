using JsonApiDotNetCore.Resources.Annotations;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Extensions;
using Notification = TdmPrototypeBackend.Types.Ipaffs.Notification;

namespace TdmPrototypeBackend.Types;

public interface ITdmRelationships
{
    public (string, TdmRelationshipObject) GetRelationshipObject();
}

public class NotificationTdmRelationships : ITdmRelationships
{
    [Attr] public TdmRelationshipObject Movements { get; set; } = TdmRelationshipObject.CreateDefault();

    public (string, TdmRelationshipObject) GetRelationshipObject()
    {
        return ("movements", Movements);
    }
}

public class GmrTdmRelationships : ITdmRelationships
{
    [Attr] public TdmRelationshipObject Transits { get; set; } = TdmRelationshipObject.CreateDefault();

    public (string, TdmRelationshipObject) GetRelationshipObject()
    {
        return ("transits", Transits);
    }
}

public class MovementTdmRelationships : ITdmRelationships
{
    [Attr] public TdmRelationshipObject Notifications { get; set; } = TdmRelationshipObject.CreateDefault();

    public (string, TdmRelationshipObject) GetRelationshipObject()
    {
        return ("notifications", Notifications);
    }
}

public sealed class TdmRelationshipObject
{
    [Attr] public bool Matched { get; set; }

    [Attr] public RelationshipLinks Links { get; set; }

    [Attr] public List<RelationshipDataItem> Data { get; set; } = new();

    public static TdmRelationshipObject CreateDefault()
    {
        return new TdmRelationshipObject { Matched = false };
    }
}

public sealed class RelationshipLinks
{
    [Attr] public string Self { get; set; }

    [Attr] public string Related { get; set; }

    public static RelationshipLinks CreateForMovement(Movement movement)
    {
        return new RelationshipLinks
        {
            Self = LinksBuilder.Movement.BuildSelfLink(movement.Id),
            Related = LinksBuilder.Movement.BuildRelatedMovementLink(movement.Id)
        };
    }

    public static RelationshipLinks CreateForNotification(Notification notification)
    {
        return new RelationshipLinks
        {
            Self = LinksBuilder.Notification.BuildSelfLink(notification.Id),
            Related = LinksBuilder.Notification.BuildRelatedMovementLink(notification.Id)
        };
    }
}

public sealed class ResourceLink
{
    [Attr] public string Self { get; set; }
}

public sealed class RelationshipDataItem
{
    [Attr] public bool Matched { get; set; } = default!;

    [Attr] public string Type { get; set; }

    [Attr] public string Id { get; set; }

    [Attr] public ResourceLink Links { get; set; }

    [Attr] public int? SourceItem { get; set; } = default!;

    [Attr] public int? DestinationItem { get; set; } = default!;

    //[Attr]
    //public Dictionary<string, string> AdditionalInformation { get; set; } e.g. "matchingLevel", "reason"

    public int? MatchingLevel { get; set; }

    public static RelationshipDataItem CreateFromNotification(Notification notification, Items item,
        bool matched = true, string reason = null)
    {
        return new RelationshipDataItem
        {
            Matched = matched,
            Type = "notifications",
            Id = notification.Id,
            SourceItem = item?.ItemNumber,
            DestinationItem = notification.Commodities?.FirstOrDefault()?.ComplementId,
            Links = new ResourceLink() { Self = LinksBuilder.Notification.BuildSelfLink(notification.Id) },
            MatchingLevel = 1
        };
    }

    public static RelationshipDataItem CreateFromMovement(Movement movement, Items item, string matchReference,
        bool matched = true, string reason = null)
    {
        return new RelationshipDataItem
        {
            Matched = matched,
            Type = "movements",
            Id = movement.Id,
            SourceItem = item?.ItemNumber,
            DestinationItem = movement.Items
                .FirstOrDefault(x => x.Documents.Any(d => d.DocumentReference.Contains(matchReference)))
                ?.ItemNumber,
            Links = new ResourceLink() { Self = LinksBuilder.Movement.BuildSelfLink(movement.Id) },
            MatchingLevel = 1
        };
    }
}