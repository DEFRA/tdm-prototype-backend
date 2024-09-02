using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmDataModel;

[Resource]
public class Item : HexStringMongoIdentifiable
{
    [Attr]
    public string A { get; set; } = default!;
    
    [Attr]
    public string B { get; set; } = default!;
}