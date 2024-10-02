using Microsoft.Extensions.Configuration;

namespace TdmPrototypeCdsSimulator.Config;

public class CdsSimulatorConfig //: IBusConfig
{
    public string DmpEnvironment { get; set; } = default!;
    public string DmpBusNamespace { get; set; } = default!;
    public string DmpBusTopic { get; set; } = default!;
    public string DmpBusSubscription { get; set; } = default!;
  
    public string? AzureClientId { get; set; } = default!;
    public string? AzureTenantId { get; set; } = default!;
    public string? AzureClientSecret { get; set; } = default!;

    public bool BypassAsb { get; set; } = default!;

    public CdsSimulatorConfig(IConfiguration configuration)
    {
        // CdsHttpsProxy = configuration["CDP_HTTPS_PROXY"];
        var dmpSlot = configuration["CDS_SIM_DMP_SLOT"]!;

        DmpEnvironment = configuration["DMP_ENVIRONMENT"]!;

        AzureClientId = configuration["AZURE_CLIENT_ID"];
        AzureTenantId = configuration["AZURE_TENANT_ID"];
        AzureClientSecret = configuration["AZURE_CLIENT_SECRET"];

        DmpBusNamespace = $"{configuration["DMP_SERVICE_BUS_NAME"]!}.servicebus.windows.net";
        DmpBusTopic = $"defra.trade.dmp.ingestipaffs.{DmpEnvironment}.{dmpSlot}.topic";
        DmpBusSubscription = $"defra.trade.dmp.{DmpEnvironment}.{dmpSlot}.subscription";

        BypassAsb = configuration["BYPASS_ASB"] == "true";

    }
}