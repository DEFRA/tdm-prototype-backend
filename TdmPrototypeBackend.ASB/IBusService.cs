namespace TdmPrototypeBackend.ASB;

public interface IBusService
{
    public Task<Status> CheckBusAsync();

    public Task<Status> CheckBusAsync(string uri);

    public Task SendMessageAsync<T>(T message);


}