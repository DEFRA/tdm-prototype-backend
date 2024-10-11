namespace TdmPrototypeDmpSynchroniser.Api.SensitiveData;

public interface ISensitiveDataSerializer
{
    public T Deserialize<T>(string json);
}