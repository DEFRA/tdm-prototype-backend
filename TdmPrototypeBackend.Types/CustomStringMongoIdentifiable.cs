using System.ComponentModel.DataAnnotations.Schema;
// using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace TdmPrototypeBackend.Types;

public class CustomStringMongoIdentifiable : IMongoIdentifiable
{
    /// <inheritdoc />
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    public virtual string? Id { get; set; }
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    [NotMapped]
    public string? StringId
    {
        get => Id;
        set => Id = value;
    }
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    [NotMapped]
    public string? LocalId { get; set; }
}