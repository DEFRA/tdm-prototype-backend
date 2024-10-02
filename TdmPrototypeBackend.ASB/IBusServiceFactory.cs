namespace TdmPrototypeBackend.ASB;

public interface IBusServiceFactory
{
    IBusService Create(IBusConfig config);
}