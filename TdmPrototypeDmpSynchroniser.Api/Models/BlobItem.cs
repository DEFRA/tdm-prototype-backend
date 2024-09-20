namespace TdmPrototypeDmpSynchroniser.Api.Models;

public interface IBlobItem
{
    string Name { get; set; }
    string Content { get; set; }
    
}

public class SynchroniserBlobItem : IBlobItem
{
    public string Name { get; set; } = default!;

    public string NormalisedName { get; set; } = default;
    public string Content { get; set; } = default!;
}