using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TdmPrototypeBackend.Types;

// TODO : Can we generate this from the schema file 
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

public enum NotificationType
{
    Cveda,
    Cvedp,
    Chedpp,
    Ced,
    Imp
}

public enum NotificationStatus
{
    Draft,
    Submitted,
    Validated,
    Rejected,
    InProgress,
    Amend,
    Modify,
    Replaced,
    Cancelled,
    Deleted,
    PartiallyRejected,
    SplitConsignment
}

public class IpaffsNotificationCommodityComplement
{
    
    [Attr]
    public string CommodityID { get; set; }
    
    [Attr]
    public string CommodityDescription { get; set; }
}

public class IpaffsNotificationCommodities
{
    
    [Attr]
    public MatchingStatus MatchingStatus { get; set; } = default!;
    
    // [Attr]
    // public bool GmsDeclarationAccepted { get; set; } = default!;
    //
    // [Attr]
    // public decimal? TotalGrossWeight { get; set; } = default!;
    //
    // [Attr]
    // public decimal? TotalNetWeight { get; set; } = default!;
    //
    // [Attr]
    // public decimal? TotalGrossVolume { get; set; } = default!;
    //
    // [Attr]
    // public string? TotalGrossVolumeUnit { get; set; } = default!;
    //
    [Attr]
    [JsonPropertyName("commodityComplement")]
    public IpaffsNotificationCommodityComplement[]? CommodityComplements { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("numberOfAnimals")]
    public int? NumberOfAnimals { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("numberOfPackages")]
    public int? NumberOfPackages { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("countryOfOrigin")]
    public string CountryOfOrigin { get; set; }
    //
    // [Attr]
    // public string CommodityCode { get; set; }
    //
    // [Attr]
    // public string? RegionOfOrigin { get; set; } = default!;
    //
    // [Attr]
    // public string? ConsignedCountry { get; set; } = default!;
    //
    // [Attr]
    // public bool? CommodityIntendedFor { get; set; } = default!;
}

public class IpaffsResponsiblePerson
{
    [Attr]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [Attr]
    [JsonPropertyName("companyId")]
    public string CompanyId { get; set; }
    
    [Attr]
    [JsonPropertyName("companyName")]
    public string CompanyName { get; set; }
    
    [Attr]
    [JsonPropertyName("country")]
    public string Country { get; set; }
}

public class IpaffsPartOne
{
    [Attr]
    [JsonPropertyName("personResponsible")]
    public IpaffsResponsiblePerson PersonResponsible { get; set; }
    
    [Attr]
    [JsonPropertyName("commodities")]
    public IpaffsNotificationCommodities? Commodities { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("pointOfEntry")]
    public string PointOfEntry { get; set; }
    
    [Attr]
    [JsonPropertyName("arrivalDate")]
    public string ArrivalDate { get; set; }
    
    [Attr]
    [JsonPropertyName("arrivalTime")]
    public string ArrivalTime { get; set; }
}

[Resource]
public class IpaffsNotification : IMongoIdentifiable
{

    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "ipaffsNotifications";
    
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonPropertyName("referenceNumber")]
    public virtual string? Id { get; set; }
    
    // TODO : this is currently being written on the wire by the json api client
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    // [NotMapped]
    [Attr]
    public string? StringId
    {
        get => Id;
        set => Id = value;
    }
    
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    [NotMapped]
    // [Attr]
    public string? LocalId { get; set; }
    
    // [JsonPropertyName("referenceNumber")]
    // public new string? Id { get; set; }
    
    // [Attr]
    // [JsonPropertyName("referenceNumber")]
    // public new string ReferenceNumber { get; set; } = default!;
    
    [Attr]
    public MatchingStatus Movement { get; set; } = new MatchingStatus() { Matched = false };
    
    [Attr]
    [JsonPropertyName("id")]
    public int IpaffsId { get; set; } = default!;
    
    [Attr]
    public int Version { get; set; } = default!;

    [Attr]
    public NotificationType NotificationType { get; set; } = default!;
    
    [Attr]
    public NotificationStatus Status { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("partOne")]
    public IpaffsPartOne PartOne { get; set; } = default!;
}