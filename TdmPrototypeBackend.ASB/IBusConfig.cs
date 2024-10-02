using TdmPrototypeBackend.Azure;

namespace TdmPrototypeBackend.ASB;

public interface IBusConfig : IAzureConfig
{
    public string DmpBusNamespace { get;  } 
    public string DmpBusTopic { get;  } 
    public string DmpBusSubscription { get; } 

}