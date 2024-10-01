using Azure;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Api.Extensions;

namespace TdmPrototypeBackend.Api.JsonApi;

// Allows us to intercept resource requests and responses and manipulate them
// https://www.jsonapi.net/usage/extensibility/resource-definitions.html

public class NotificationResource(IResourceGraph resourceGraph, ITdmClaimsProvider tdmClaimsProvider) : JsonApiResourceDefinition<Notification, string>(resourceGraph)
{
    TdmClaimsPrincipal _principal = tdmClaimsProvider.TdmClaimsPrincipal;
    
    // This method is called twice, once during request processing which impacts the query and once during response
    // processing which removes fields from the response
    
    public override SparseFieldSetExpression? OnApplySparseFieldSet(
        SparseFieldSetExpression? existingSparseFieldSet)
    {
        if (existingSparseFieldSet != null)
        {
            // Firstly we want to remove the internal fields we add to the model for filtering as we don't want
            // them exposed to end users
            // TODO : hopefully there's a ey to exclude these by looking for the underscore prefix
            existingSparseFieldSet = existingSparseFieldSet
                    .Excluding<Notification>(n => n._PointOfEntry, ResourceGraph)
                    .Excluding<Notification>(n => n._PointOfEntryControlPoint, ResourceGraph);

            // Then, we remove fields based on the user
            // For example only exposing the audit log to internal users
            if (_principal.OrgType != OrgType.Internal)
            {
                existingSparseFieldSet = existingSparseFieldSet
                    .Excluding<Notification>(n => n.AuditEntries, ResourceGraph);
            }
        }
        
        return existingSparseFieldSet;
    }
    
    public override FilterExpression? OnApplyFilter(FilterExpression? existingFilter)
    {
        if (_principal.OrgType == OrgType.Pha)
        {
            
            // IF its a PHA we want to filter on just the one point of entry
            // NB, awaiting confirmation of how this is planned to work

            var attribute = ResourceType.Attributes.Single(n =>
                n.Property.Name == nameof(Notification._PointOfEntry));
        
            var expression = new ComparisonExpression(ComparisonOperator.Equals,
                new ResourceFieldChainExpression(attribute),
                new LiteralConstantExpression(_principal.OrgId));
            
            return existingFilter == null
                ? (FilterExpression) expression
                : new LogicalExpression(LogicalOperator.And,
                    new[] { expression, existingFilter });
        }
        else
        {
            return existingFilter;
        }
    }
}