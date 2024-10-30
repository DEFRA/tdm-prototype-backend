using JsonApiDotNetCore.Resources.Annotations;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Api.Swagger
{
    public class NotificationResourceResponse : ResourceResponse<NotificationResourceData>
    {
    }

    public class JsonApiTdmRelationshipMeta
    {
        [Attr] public bool Matched { get; set; } = default!;
    }

    public class TdmDataMeta
    {
        [Attr] public bool Matched { get; set; } = default!;

        [Attr] public string Self { get; set; }

        [Attr] public int? SourceItem { get; set; } = default!;

        [Attr] public int? DestinationItem { get; set; } = default!;

        [Attr] public int? MatchingLevel { get; set; }
    }


    public class NotificationJsonApiTdmRelationships
    {
        [Attr] public JsonApiTdmRelationshipObject Movements { get; set; }
    }

    public class GrmJsonApiTdmRelationships
    {
        [Attr] public GrmJsonApiTdmRelationshipObject Transits { get; set; }

        [Attr] public GrmJsonApiTdmRelationshipObject Customs { get; set; }
    }

    public class MovementJsonApiTdmRelationships
    {
        [Attr] public JsonApiTdmRelationshipObject Notifications { get; set; }
    }

    public sealed class GrmJsonApiTdmRelationshipObject
    {
        [Attr] public JsonApiRelationshipLinks Links { get; set; }
    }

    public sealed class JsonApiTdmRelationshipObject
    {
        [Attr] public JsonApiTdmRelationshipMeta Meta { get; set; } = default!;

        [Attr] public JsonApiRelationshipLinks Links { get; set; }

        [Attr] public List<JsonApiRelationshipDataItem> Data { get; set; } = new List<JsonApiRelationshipDataItem>();
    }


    public sealed class JsonApiRelationshipLinks
    {
        [Attr] public string Self { get; set; }

        [Attr] public string Related { get; set; }
    }

    //public sealed class JsonApiResourceLink
    //{
    //    [Attr]
    //    public string Self { get; set; }
    //}

    public sealed class JsonApiRelationshipDataItem
    {
        [Attr] public string Type { get; set; }

        [Attr] public string Id { get; set; }

        [Attr] public TdmDataMeta Meta { get; set; }
    }
}