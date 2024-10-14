namespace TdmPrototypeBackend.Cli.Features.GenerateModels.ClassMaps;

static class Bootstrap
{
    public static void GeneratorClassMaps()
    {
        RegisterAlvsClassMaps();
        RegisterIpaffsClassMaps();

        RegisterVehicleMovementsClassMaps();
    }

    public static void RegisterAlvsClassMaps()
    {
        GeneratorClassMap.RegisterClassMap("Header", map =>
        {
            map.MapProperty("ArrivalDateTime").SetType("DateTime");
        });
    }

    public static void RegisterIpaffsClassMaps()
    {
        GeneratorEnumMap.RegisterEnumMap("purposeGroup", map =>
        {
            map.AddEnumValue("For Import Non-Internal Market");
        });

        GeneratorClassMap.RegisterClassMap("Notification", map =>
        {
            map.MapProperty("riskDecisionLockingTime").SetType("DateTime");
            map.MapProperty("decisionDate").SetType("DateTime");
            map.MapProperty("lastUpdated").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("Commodities", map =>
        {
            map.MapProperty("complementParameterSet").AddAttribute("[MongoDB.Bson.Serialization.Attributes.BsonIgnore]");
        });

        GeneratorClassMap.RegisterClassMap("ComplementParameterSet", map =>
        {
            map.MapProperty("KeyDataPair")
                .SetType("IDictionary<string, object>")
                .AddAttribute("[JsonConverter(typeof(KeyDataPairsToDictionaryStringObjectJsonConverter))]");
        });


        GeneratorClassMap.RegisterClassMap("EconomicOperator", map =>
        {
            map.MapProperty("individualName").IsSensitive();
            map.MapProperty("companyName").IsSensitive();
        });

        GeneratorClassMap.RegisterClassMap("Address", map =>
        {
            map.MapProperty("Street").IsSensitive();
            map.MapProperty("City").IsSensitive();
            map.MapProperty("postalCode").IsSensitive();
            map.MapProperty("addressLine1").IsSensitive();
            map.MapProperty("addressLine2").IsSensitive();
            map.MapProperty("addressLine3").IsSensitive();
            map.MapProperty("postalZipCode").IsSensitive();
            map.MapProperty("email").IsSensitive();
            map.MapProperty("ukTelephone").IsSensitive();
            map.MapProperty("telephone").IsSensitive();
        });


        GeneratorClassMap.RegisterClassMap("Party", map =>
        {
            map.MapProperty("email").IsSensitive();
            map.MapProperty("fax").IsSensitive();
            map.MapProperty("phone").IsSensitive();
            map.MapProperty("city").IsSensitive();
            map.MapProperty("postCode").IsSensitive();
            map.MapProperty("Address").IsSensitive();
            map.MapProperty("companyName").IsSensitive();
            map.MapProperty("name").IsSensitive();
        });

        GeneratorClassMap.RegisterClassMap("UserInformation", map =>
        {
            map.MapProperty("displayName").IsSensitive();
        });
    }


    public static void RegisterVehicleMovementsClassMaps()
    {
        GeneratorClassMap.RegisterClassMap("gmrs", map =>
        {
            map.SetClassName("Gmr");
            map.MapProperty("haulierEORI").SetName("haulierEori");
            map.MapProperty("vehicleRegNum").SetName("vehicleRegNumber");
            map.MapProperty("updatedDateTime").SetName("lastUpdated").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("SearchGmrsForDeclarationIdsResponse", map =>
        {
            map.MapProperty("Gmrs").SetType("Gmr[]");
        });

        GeneratorClassMap.RegisterClassMap("SearchGmrsForVRNsresponse", map =>
        {
            map.MapProperty("Gmrs").SetType("Gmr[]");
        });

        GeneratorClassMap.RegisterClassMap("SearchGmrsResponse", map =>
        {
            map.MapProperty("Gmrs").SetType("Gmr[]");
        });


        GeneratorClassMap.RegisterClassMap("PlannedCrossing", map =>
        {
            map.MapProperty("localDateTimeOfDeparture").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("ActualCrossing", map =>
        {
            map.MapProperty("localDateTimeOfArrival").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("CheckedInCrossing", map =>
        {
            map.MapProperty("localDateTimeOfArrival").SetType("DateTime");
        });
    }
}