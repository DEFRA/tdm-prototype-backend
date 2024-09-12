using System.ComponentModel.DataAnnotations.Schema;
using JsonApiDotNetCore.MongoDb.Resources;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

// Custom implementation of FreeStringMongoIdentifiable from JsonApiDotNetCore.MongoDb
// with an attribute on StringId to prevent it being serialised by the client we're using
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