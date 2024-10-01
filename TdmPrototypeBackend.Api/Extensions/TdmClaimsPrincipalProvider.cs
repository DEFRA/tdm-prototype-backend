using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace TdmPrototypeBackend.Api.Extensions;

public interface ITdmClaimsProvider
{
    public TdmClaimsPrincipal TdmClaimsPrincipal { get; }
}

public enum OrgType
{
    Pha,
	Internal
}

public class TdmClaimsTransformer : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var customPrincipal = new TdmClaimsPrincipal(principal) as ClaimsPrincipal;
        return Task.FromResult(customPrincipal);
    }
}

public class TdmClaimsPrincipal : ClaimsPrincipal
{
    public TdmClaimsPrincipal(ClaimsPrincipal claimsPrincipal): base(claimsPrincipal)
    {
        
        // ClaimsPrincipal = claimsPrincipal;
        // Claims = claimsPrincipal.Claims;
        
        var relationships = base.Claims
            .Where(c => c.Type == "relationships")
            .Select(c => c.Value).Single()
            .Split(":");
        
        // Console.WriteLine(relationships);
        
        if (relationships.FirstOrDefault() == "PHA")
        {
            OrgType = OrgType.Pha;
            OrgId = relationships[1];
            OrgName = relationships[2];
        }
        else
        {
            OrgType = OrgType.Internal;
        }
        
        ((ClaimsIdentity)Identity).AddClaim(new Claim("tdm-technical","true"));
        
    }
    
    public override bool IsInRole(string role)
    {
        Console.WriteLine($"TdmClaimsPrincipal {base.Identity!.Name} IsInRole: {role}");
        return base.IsInRole(role);
    }

    public override bool HasClaim(string type, string value)
    {
        Console.WriteLine($"TdmClaimsPrincipal {base.Identity!.Name} HasClaim: {type}, {value}");
        return base.HasClaim(type, value);
    }
    
    public ClaimsPrincipal ClaimsPrincipal { get; private set; }
    public OrgType OrgType { get; private set; }
    public string OrgId { get; private set; }
    public string OrgName { get; private set; }
    public IEnumerable<Claim> Claims { get; private set; }
}

public class TdmClaimsPrincipalProvider(IHttpContextAccessor httpContext) : ITdmClaimsProvider
{
    public TdmClaimsPrincipal TdmClaimsPrincipal { get; private set; } = new(httpContext!.HttpContext!.User as ClaimsPrincipal);
}