namespace TdmPrototypeBackend.Types.Extensions;

public class SensitiveDataOptions
{
    public bool Include { get; set; }

    public Func<string> Getter { get; set; } = () => "[REDACTED]";
}