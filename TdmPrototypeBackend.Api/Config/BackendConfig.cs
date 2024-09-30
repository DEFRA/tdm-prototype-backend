namespace TdmPrototypeBackend.Api.Config;

public class BackendConfig
{
    public bool EnableMongoManagement { get; set; } = default!;
    public bool DisableAuthorisation { get; set; } = default!;
    
    public BackendConfig(IConfiguration configuration)
    {
        EnableMongoManagement = configuration["ENABLE_MONGO_MANAGEMENT"] == "true";
        DisableAuthorisation = configuration["DISABLE_AUTHORISATION"] == "true";
    }
}