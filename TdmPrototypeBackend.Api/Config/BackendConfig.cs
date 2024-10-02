namespace TdmPrototypeBackend.Api.Config;

public class BackendConfig
{
    public bool EnableManagement { get; set; } = default!;
    public bool DisableAuthorisation { get; set; } = default!;
    
    public BackendConfig(IConfiguration configuration)
    {
        EnableManagement = configuration["ENABLE_MANAGEMENT"] == "true";
        DisableAuthorisation = configuration["DISABLE_AUTHORISATION"] == "true";
    }
}