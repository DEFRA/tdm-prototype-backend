using JsonApiDotNetCore.Resources.Annotations;

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
    public IpaffsNotificationCommodityComplement[]? CommodityComplement { get; set; } = default!;
    
    [Attr]
    public int? NumberOfAnimals { get; set; } = default!;
    
    [Attr]
    public int? NumberOfPackages { get; set; } = default!;
    
    [Attr]
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
    public string Name { get; set; }
    [Attr]
    public string CompanyId { get; set; }
    [Attr]
    public string CompanyName { get; set; }
    [Attr]
    public string Country { get; set; }
}

public class IpaffsPartOne
{
    [Attr]
    public IpaffsResponsiblePerson PersonResponsible { get; set; }
    
    [Attr]
    public IpaffsNotificationCommodities[]? Commodities { get; set; } = default!;
    
    [Attr]
    public string PointOfEntry { get; set; }
    
    [Attr]
    public string ArrivalDate { get; set; }
    
    [Attr]
    public string ArrivalTime { get; set; }
}

[Resource]
public class IpaffsNotification : CustomStringMongoIdentifiable
{

    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "ipaffsNotifications";
    
    [Attr]
    public MatchingStatus Movement { get; set; } = new MatchingStatus() { Matched = false };
    
    [Attr]
    public int Version { get; set; } = default!;

    [Attr]
    public NotificationType NotificationType { get; set; } = default!;
    
    [Attr]
    public NotificationStatus Status { get; set; } = default!;
    
    [Attr]
    public IpaffsPartOne PartOne { get; set; } = default!;
}