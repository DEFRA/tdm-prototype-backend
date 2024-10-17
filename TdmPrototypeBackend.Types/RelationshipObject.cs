using System.Collections.Generic;
using System.Text.Json.Serialization;
using JsonApiDotNetCore.Resources.Annotations;
using JsonApiDotNetCore.Serialization.Objects;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Types;

public interface ITdmRelationships
{

}

public class NotificationTdmRelationships : ITdmRelationships
{
    [Attr] 
    public TdmRelationshipObject Movements { get; set; } = TdmRelationshipObject.CreateDefault();
}

public class MovementTdmRelationships : ITdmRelationships
{
    [Attr]
    public TdmRelationshipObject Notifications { get; set; } = TdmRelationshipObject.CreateDefault();
}

public sealed class TdmRelationshipObject
{
    [Attr]
    public bool Matched { get; set; } = default!;

    [Attr]
    public RelationshipLinks Links { get; set; }

    [Attr]
    public List<RelationshipDataItem> Data { get; set; } = new List<RelationshipDataItem>();

    public static TdmRelationshipObject CreateDefault()
    {
        return new TdmRelationshipObject() { Matched = false };
    }
}


public sealed class RelationshipLinks
{
    [Attr]
    public string Self { get; set; }

    [Attr]
    public string Related { get; set; }

    public static RelationshipLinks CreateForMovement(Movement movement)
    {
        return new RelationshipLinks()
        {
            Self = LinksBuilder.Movement.BuildSelfLink(movement.Id),
            Related = LinksBuilder.Movement.BuildRelatedMovementLink(movement.Id)
        };
    }

    public static RelationshipLinks CreateForNotification(Notification notification)
    {
        return new RelationshipLinks()
        {
            Self = LinksBuilder.Notification.BuildSelfLink(notification.Id),
            Related = LinksBuilder.Notification.BuildRelatedMovementLink(notification.Id)
        };
    }
}

public sealed class ResourceLink
{
    [Attr]
    public string Self { get; set; }
}

public sealed class RelationshipDataItem 
{
    [Attr]
    public bool Matched { get; set; } = default!;

    [Attr]
    public string Type { get; set; }

    [Attr]
    public string Id { get; set; }

    [Attr]
    public ResourceLink Links { get; set; }
    
    [Attr]
    public int? SourceItem { get; set; } = default!;

    [Attr]
    public int? DestinationItem { get; set; } = default!;

    [Attr]
    public Dictionary<string, string> AdditionalInformation { get; set; }

    public static RelationshipDataItem CreateFromNotification(Notification notification, Movement movement, string matchReference, bool matched = true, string reason = null)
    {
        Dictionary<string, string> additionalInfo = new Dictionary<string, string>() { { "matchingLevel", "1" } };

        if (!string.IsNullOrEmpty(reason))
        {
            additionalInfo.Add("reason", reason);
        }

        return new RelationshipDataItem()
        {
            Matched = matched,
            Type = "notifications",
            Id = notification.Id,
            SourceItem = movement.Items
                .FirstOrDefault(x => x.Documents.Any(d => d.DocumentReference.Contains(matchReference)))
                ?.ItemNumber,
            DestinationItem = notification.Commodities?.FirstOrDefault()?.ComplementID,
            Links = new ResourceLink() { Self = LinksBuilder.Notification.BuildSelfLink(notification.Id) },
            AdditionalInformation = additionalInfo
        };
    }

    public static RelationshipDataItem CreateFromMovement(Notification notification, Movement movement, string matchReference, bool matched = true, string reason = null)
    {
        Dictionary<string, string> additionalInfo = new Dictionary<string, string>() { { "matchingLevel", "1" } };

        if (!string.IsNullOrEmpty(reason))
        {
            additionalInfo.Add("reason", reason);
        }
        return new RelationshipDataItem()
        {
            Matched = matched,
            Type = "movements",
            Id = movement.Id,
            SourceItem = notification?.Commodities?.FirstOrDefault()?.ComplementID,
            DestinationItem = movement.Items
                .FirstOrDefault(x => x.Documents.Any(d => d.DocumentReference.Contains(matchReference)))
                ?.ItemNumber,
            Links = new ResourceLink()
            {
                Self = LinksBuilder.Movement.BuildSelfLink(movement.Id)
            },
            AdditionalInformation = additionalInfo
        };
    }

}