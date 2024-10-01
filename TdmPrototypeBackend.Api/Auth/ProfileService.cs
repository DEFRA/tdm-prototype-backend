using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace TdmPrototypeBackend.Api.Auth;

// public class ProfileService : IProfileService
// {
//     protected UserManager<ApplicationUser> _userManager;
//
//     public ProfileService(UserManager<ApplicationUser> userManager)
//     {
//         _userManager = userManager;
//     }
//
//     public Task GetProfileDataAsync(ProfileDataRequestContext context)
//     {
//         var user = _userManager.GetUserAsync(context.Subject).Result;
//
//         var claims = new List<Claim>
//         {
//             new Claim(IdentityModel.JwtClaimTypes.Email, user.Email)
//         };
//         context.IssuedClaims.AddRange(claims);
//         
//         return Task.FromResult(0);
//     }
//
//     public Task IsActiveAsync(IsActiveContext context)
//     {
//         var user = _userManager.GetUserAsync(context.Subject).Result;
//
//         context.IsActive = (user != null);
//         
//         return Task.FromResult(0);
//     }
// }