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
    }

    public static void RegisterVehicleMovementsClassMaps()
    {
        GeneratorClassMap.RegisterClassMap("Gmrs", map =>
        {
            map.MapProperty("updatedDateTime").SetType("DateTime");
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