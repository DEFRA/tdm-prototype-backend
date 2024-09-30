using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using TdmPrototypeBackend.Api.Config;


namespace TdmPrototypeBackend.Api.Extensions;

public static class ServiceExtensions
{

    public static void AddTdmAuthorisation(this WebApplicationBuilder builder, BackendConfig config)
    {
        // builder.AddAuthorization();

        if (!config.DisableAuthorisation)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("DefraId")
                    .Build();
            
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("DefraId")
                    .Build();
            });
        }
        
    }

    public static void AddTdmAuthentication(this WebApplicationBuilder builder)
    {
        
        // builder.us
        // TODO : Remove this once working
        IdentityModelEventSource.ShowPII = true;
        IdentityModelEventSource.LogCompleteSecurityArtifact = true;
        
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            
        }).AddJwtBearer("DefraId",o =>
        {
            o.IncludeErrorDetails = true;
            
            o.TokenValidationParameters = new TokenValidationParameters
            {
                // ValidIssuer = builder.Configuration["Jwt:Issuer"],
                // ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = false,
                ValidateActor = false,
                RequireSignedTokens = false,
                // TODO : Don't want to fail when the JWT doesn't include a kid
                // https://github.com/dotnet/aspnetcore/issues/52075
                SignatureValidator = (token, _) => new JsonWebToken(token)
            };
            
            o.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    Console.WriteLine($"OnMessageReceived");
                    // if (!context.Request.Headers.ContainsKey("Authorization"))
                    // {
                    //     context.Response.StatusCode = 401;
                    //     context.Fail($"Authorization header not found");
                    // }
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    Console.WriteLine($"OnTokenValidated");
                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    Console.WriteLine($"OnForbidden");
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    Console.WriteLine($"OnChallenge");
                    return Task.CompletedTask;
                }, 
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                        context.Response.StatusCode = 408;
                        context.Fail($"Token Expired");
                        // context.
                        // return Task
                    }
                    else if (context.Exception.GetType() == typeof(SecurityTokenSignatureKeyNotFoundException))
                    {
                        context.Response.StatusCode = 401;
                        context.Fail($"Security token key not found");
                    }
                    else if (context.Response.GetType() == typeof(SecurityTokenInvalidSignatureException))
                    {
                        Console.WriteLine("SecurityTokenInvalidSignatureException");
                        // context.Response.StatusCode = 408;
                        // context.Fail($"Security token signature is invalid");
                    }

                    // if no token is set 
                    // context.Response.StatusCode = 402; // check if bearer has token
                    // Console.WriteLine($"no token has been set {context.Response.StatusCode = 408}");

                    return Task.CompletedTask;
                }
            };
        });
        
    }
}