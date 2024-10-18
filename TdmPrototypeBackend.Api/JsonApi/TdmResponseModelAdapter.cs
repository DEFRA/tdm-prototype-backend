using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.QueryStrings;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Serialization.Objects;
using JsonApiDotNetCore.Serialization.Response;
using TdmPrototypeBackend.Types;
using RelationshipLinks = JsonApiDotNetCore.Serialization.Objects.RelationshipLinks;

namespace TdmPrototypeBackend.Api.JsonApi;

public class TdmResponseModelAdapter(
    IJsonApiRequest request,
    IJsonApiOptions options,
    ILinkBuilder linkBuilder,
    IMetaBuilder metaBuilder,
    IResourceDefinitionAccessor resourceDefinitionAccessor,
    IEvaluatedIncludeCache evaluatedIncludeCache,
    ISparseFieldSetCache sparseFieldSetCache,
    IRequestQueryStringAccessor requestQueryStringAccessor)
    : IResponseModelAdapter
{
    private readonly IResponseModelAdapter inner = new ResponseModelAdapter(request, options, linkBuilder, metaBuilder, resourceDefinitionAccessor,
        evaluatedIncludeCache, sparseFieldSetCache, requestQueryStringAccessor);

    public Document Convert(object? model)
    {
        var document = inner.Convert(model);
        if(document.Data.SingleValue.Attributes.TryGetValue("relationships", out var value))
        {
            var relationships = (value as ITdmRelationships).GetRelationshipObject();

            document.Data.SingleValue.Relationships = new Dictionary<string, RelationshipObject?>();

            var list = relationships.Value.Data.Select(item => new ResourceIdentifierObject()
                {
                    Type = item.Type, 
                    Id = item.Id, 
                    //Lid = item.Id, 
                    Meta = new Dictionary<string, object?>()
                    {
                        { "matched", item.Matched }, 
                        { "sourceItem", item.SourceItem }, 
                        { "destinationItem", item.DestinationItem },
                        { "additionalInformation", item.AdditionalInformation },
                        { "self", item.Links.Self}
                    },
                })
                .ToList();


            document.Data.SingleValue.Relationships.Add(relationships.Name, new RelationshipObject()
            {
                Meta = new Dictionary<string, object?>()
                {
                    {"matched", relationships.Value.Matched}
                },
                Links = new RelationshipLinks()
                {
                    Self = relationships.Value.Links.Self,
                    Related = relationships.Value.Links.Self
                },
                Data = new SingleOrManyData<ResourceIdentifierObject>(list)
            });

            document.Data.SingleValue.Attributes.Remove("relationships");
        }
        return document;
    }
}