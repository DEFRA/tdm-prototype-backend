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

        GeneratorClassMap.RegisterClassMap("AccompanyingDocument", map =>
        {
            map.MapProperty("documentIssueDate").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("InspectionOverride", map =>
        {
            map.MapProperty("overriddenOn").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("SealCheck", map =>
        {
            map.MapProperty("dateTimeOfCheck").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("LaboratoryTestResult", map =>
        {
            map.MapProperty("releasedDate").SetType("DateTime");
            map.MapProperty("labTestCreatedDate").SetType("DateTime");
        });

        GeneratorClassMap.RegisterClassMap("DetailsOnReExport", map =>
        {
            map.MapProperty("date").SetType("DateTime");
            map.MapProperty("exitBIP").SetName("exitBip");
        });

        GeneratorClassMap.RegisterClassMap("Notification", map =>
        {
            map.MapProperty("isGMRMatched").SetName("isGmrMatched");
            map.MapProperty("riskDecisionLockingTime").SetType("DateTime");
            map.MapProperty("decisionDate").SetType("DateTime");
            map.MapProperty("lastUpdated").SetType("DateTime");
            map.MapProperty("referenceNumber").SetBsonIgnore();
        });

        GeneratorClassMap.RegisterClassMap("Commodities", map =>
        {
            map.MapProperty("complementParameterSet").SetBsonIgnore();
            map.MapProperty("commodityComplement").SetBsonIgnore();
        });

        GeneratorClassMap.RegisterClassMap("PartOne", map =>
        {
            map.MapProperty("commodities").SetBsonIgnore();
        });

        GeneratorClassMap.RegisterClassMap("PartTwo", map =>
        {
            map.MapProperty("commodityChecks").SetBsonIgnore();
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
            map.MapProperty("countryISOCode").SetName("countryIsoCode");
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

        GeneratorClassMap.RegisterClassMap("OfficialVeterinarian", map =>
        {
            map.MapProperty("firstName").IsSensitive();
            map.MapProperty("lastName").IsSensitive();
            map.MapProperty("email").IsSensitive();
            map.MapProperty("phone").IsSensitive();
            map.MapProperty("fax").IsSensitive();
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