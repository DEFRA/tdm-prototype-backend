using AutoBogus;
using FluentAssertions;
using Tdm.SensitiveData.SensitiveData;
using Tdm.Types.Ipaffs;
using Tdm.Types.Ipaffs.Mapping.Tests;
using Xunit;

namespace Tdm.Types.Alvs.Mapping.Tests;

public class CheckMapperTests
{
    [Fact]
    public void CHEDPTest()
    {
        var s =
            "{\n    \"id\": 36543,\n    \"referenceNumber\": \"CHEDP.GB.2024.1036543\",\n    \"version\": 1,\n    \"lastUpdated\": \"2024-09-12T12:13:47.923Z\",\n    \"lastUpdatedBy\": {\n        \"displayName\": \"Mark Admin-Tester\",\n        \"userId\": \"79f6dc68-2144-e911-a96a-000d3a29ba60\"\n    },\n    \"type\": \"CVEDP\",\n    \"status\": \"SUBMITTED\",\n    \"riskAssessment\": {\n        \"commodityResults\": [\n            {\n                \"riskDecision\": \"REQUIRED\",\n                \"uniqueId\": \"49431dfe-bc23-4fb4-aa78-ad6fd8388350\"\n            }\n        ],\n        \"assessmentDateTime\": \"2024-09-12T13:13:47.8943619\"\n    },\n    \"journeyRiskCategorisation\": {\n        \"riskLevel\": \"Low\",\n        \"riskLevelMethod\": \"User\",\n        \"riskLevelDateTime\": \"2024-09-12T12:12:18.627\"\n    },\n    \"isHighRiskEuImport\": false,\n    \"partOne\": {\n        \"personResponsible\": {\n            \"name\": \"Mark Admin-Tester\",\n            \"companyId\": \"767ceb6a-2144-e911-a96c-000d3a29b5de\",\n            \"companyName\": \"Defra Test BIP\",\n            \"address\": [\n                \"Animal and Plant Health Agency\",\n                \"Woodham Lane\",\n                \"New Haw\",\n                \"Surrey\",\n                \"Addlestone\",\n                \"KT15 3NB\"\n            ],\n            \"country\": \"GB\",\n            \"tracesID\": 1001,\n            \"phone\": \"020 8225 7295\",\n            \"email\": \"DefraTestBIP@anthunt3.33mail.com\",\n            \"contactId\": \"79f6dc68-2144-e911-a96a-000d3a29ba60\"\n        },\n        \"consignor\": {\n            \"id\": \"2ab17df9-e875-4bb9-a5e9-4c9ce6c5695c\",\n            \"type\": \"exporter\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"f10888e8744d402c963c13352b53e736\",\n            \"address\": {\n                \"addressLine1\": \"53096 Murphy Station\",\n                \"addressLine2\": \"Suite 555\",\n                \"addressLine3\": \"Kansas\",\n                \"city\": \"South Ryleyview\",\n                \"postalZipCode\": \"12674\",\n                \"countryISOCode\": \"PL\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10005792\n        },\n        \"consignee\": {\n            \"id\": \"6d8f4fa7-594a-462f-9008-9a39276225ea\",\n            \"type\": \"consignee\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"4b1a8571489f43368438ffe5c148fc2a\",\n            \"address\": {\n                \"addressLine1\": \"610 Arthur Roads\",\n                \"addressLine2\": \"Suite 843\",\n                \"addressLine3\": \"Maryland\",\n                \"city\": \"Port Alvinaside\",\n                \"postalZipCode\": \"91444\",\n                \"countryISOCode\": \"GB\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10008612\n        },\n        \"importer\": {\n            \"id\": \"6d8f4fa7-594a-462f-9008-9a39276225ea\",\n            \"type\": \"importer\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"4b1a8571489f43368438ffe5c148fc2a\",\n            \"address\": {\n                \"addressLine1\": \"610 Arthur Roads\",\n                \"addressLine2\": \"Suite 843\",\n                \"addressLine3\": \"Maryland\",\n                \"city\": \"Port Alvinaside\",\n                \"postalZipCode\": \"91444\",\n                \"countryISOCode\": \"GB\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10008612\n        },\n        \"placeOfDestination\": {\n            \"id\": \"6d8f4fa7-594a-462f-9008-9a39276225ea\",\n            \"type\": \"destination\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"4b1a8571489f43368438ffe5c148fc2a\",\n            \"address\": {\n                \"addressLine1\": \"610 Arthur Roads\",\n                \"addressLine2\": \"Suite 843\",\n                \"addressLine3\": \"Maryland\",\n                \"city\": \"Port Alvinaside\",\n                \"postalZipCode\": \"91444\",\n                \"countryISOCode\": \"GB\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10008612\n        },\n        \"commodities\": {\n            \"totalGrossWeight\": 3,\n            \"totalNetWeight\": 1,\n            \"numberOfPackages\": 1,\n            \"temperature\": \"Ambient\",\n            \"commodityComplement\": [\n                {\n                    \"commodityID\": \"0401\",\n                    \"commodityDescription\": \"Milk and cream, not concentrated nor containing added sugar or other sweetening matter\",\n                    \"complementID\": 1,\n                    \"complementName\": \"Camelus dromedarius\",\n                    \"speciesID\": \"106568\",\n                    \"speciesName\": \"Camelus dromedarius\",\n                    \"speciesTypeName\": \"Raw milk\",\n                    \"speciesType\": \"49\",\n                    \"speciesClass\": \"167425\",\n                    \"speciesNomination\": \"Camelus dromedarius\"\n                }\n            ],\n            \"complementParameterSet\": [\n                {\n                    \"uniqueComplementID\": \"49431dfe-bc23-4fb4-aa78-ad6fd8388350\",\n                    \"complementID\": 1,\n                    \"speciesID\": \"106568\",\n                    \"keyDataPair\": [\n                        {\n                            \"key\": \"netweight\",\n                            \"data\": \"1\"\n                        },\n                        {\n                            \"key\": \"number_package\",\n                            \"data\": \"1\"\n                        },\n                        {\n                            \"key\": \"type_package\",\n                            \"data\": \"Bale\"\n                        }\n                    ]\n                }\n            ],\n            \"includeNonAblactedAnimals\": false,\n            \"countryOfOrigin\": \"AF\",\n            \"consignedCountry\": \"AF\"\n        },\n        \"purpose\": {\n            \"conformsToEU\": true,\n            \"internalMarketPurpose\": \"Human Consumption\",\n            \"purposeGroup\": \"For Import\"\n        },\n        \"pointOfEntry\": \"GBMNC1\",\n        \"arrivalDate\": \"2024-09-13\",\n        \"arrivalTime\": \"10:00:00\",\n        \"transporterDetailsRequired\": false,\n        \"meansOfTransport\": {},\n        \"meansOfTransportFromEntryPoint\": {\n            \"id\": \"afssd\",\n            \"type\": \"Aeroplane\",\n            \"document\": \"kdfksdl\"\n        },\n        \"veterinaryInformation\": {},\n        \"submissionDate\": \"2024-09-12T12:13:46.307030992Z\",\n        \"submittedBy\": {\n            \"displayName\": \"Mark Admin-Tester\",\n            \"userId\": \"79f6dc68-2144-e911-a96a-000d3a29ba60\"\n        },\n        \"complexCommoditySelected\": true,\n        \"portOfEntry\": \"GBMAN\",\n        \"contactDetails\": {\n            \"name\": \"Mark Admin-Tester\",\n            \"telephone\": \"020 8225 7295\",\n            \"email\": \"defratestbip@anthunt3.33mail.com\"\n        },\n        \"isGVMSRoute\": false,\n        \"provideCtcMrn\": \"NO\"\n    },\n    \"partTwo\": {\n        \"decision\": {\n            \"decision\": \"Acceptable for Internal Market\",\n            \"freeCirculationPurpose\": \"Human Consumption\"\n        },\n        \"consignmentCheck\": {},\n        \"consignmentValidation\": [\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/decision/consignmentacceptable\",\n                \"message\": \"What is the decision for this consignment\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/consignmentcheck/physicalcheckdone\",\n                \"message\": \"Physical check\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/consignmentcheck/documentcheckresult\",\n                \"message\": \"Documentary check\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/laboratorytestsrequired\",\n                \"message\": \"Are laboratory tests required\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/consignmentcheck/identitycheckdone\",\n                \"message\": \"Identity check\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/partone/veterinaryinformation/establishmentsoforigin\",\n                \"message\": \"Approved establishment\"\n            }\n        ],\n        \"inspectionRequired\": \"Required\"\n    },\n    \"partThree\": {\n        \"sealCheckRequired\": false\n    },\n    \"consignmentValidation\": [\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/consignmentcheck/documentcheckresult\",\n            \"message\": \"Documentary check\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/consignmentcheck/identitycheckdone\",\n            \"message\": \"Identity check\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/consignmentcheck/physicalcheckdone\",\n            \"message\": \"Physical check\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/laboratorytestsrequired\",\n            \"message\": \"Are laboratory tests required\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/decision/consignmentacceptable\",\n            \"message\": \"What is the decision for this consignment\"\n        }\n    ],\n    \"etag\": \"0000000000083ED7\",\n    \"riskDecisionLockingTime\": \"2024-09-13T07:00:00Z\",\n    \"isRiskDecisionLocked\": false,\n    \"chedTypeVersion\": 1\n}";

        var sourceNotification = new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData).Deserialize<Tdm.Types.Ipaffs.Notification>(s);
        var mappedNotification = sourceNotification.MapWithTransform();
       
        mappedNotification.ShouldBeEqualTo(Tdm.Model.Ipaffs.IpaffsNotificationTypeEnum.Cvedp, Tdm.Model.Ipaffs.IpaffsNotificationStatusEnum.Submitted, s);
    }

    [Fact]
    public void CHEDATest()
    {
        var s =
            "{\"id\":26574,\"referenceNumber\":\"CHEDA.GB.2024.1026574\",\"version\":1,\"lastUpdated\":\"2024-09-03T11:45:38.585822114Z\",\"lastUpdatedBy\":{\"displayName\":\"Andrew Inspector-Tester\",\"userId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"type\":\"CVEDA\",\"status\":\"SUBMITTED\",\"isHighRiskEuImport\":true,\"partOne\":{\"personResponsible\":{\"name\":\"Mark Admin-Tester\",\"companyId\":\"767ceb6a-2144-e911-a96c-000d3a29b5de\",\"companyName\":\"Defra Test BIP\",\"address\":[\"Animal and Plant Health Agency\",\"Woodham Lane\",\"New Haw\",\"Surrey\",\"Addlestone\",\"KT15 3NB\"],\"country\":\"GB\",\"tracesID\":1001,\"phone\":\"020 8225 7295\",\"email\":\"DefraTestBIP@anthunt3.33mail.com\",\"contactId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"consignor\":{\"id\":\"d5eba566-9b57-4580-84fb-d28739fa4719\",\"type\":\"exporter\",\"status\":\"nonapproved\",\"companyName\":\"c7f606df309a417da4ec442330ddd52a\",\"address\":{\"addressLine1\":\"07584 Gillian Mews\",\"addressLine2\":\"Apt. 962\",\"addressLine3\":\"Idaho\",\"city\":\"Lake Cristina\",\"postalZipCode\":\"91645\",\"countryISOCode\":\"DE\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10008591},\"consignee\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"importer\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"placeOfDestination\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"commodities\":{\"numberOfPackages\":1,\"numberOfAnimals\":1,\"commodityComplement\":[{\"commodityID\":\"0101\",\"commodityDescription\":\"Live horses, asses, mules and hinnies\",\"complementID\":1,\"complementName\":\"Equus asinus\",\"speciesID\":\"242089\",\"speciesName\":\"Equus asinus\",\"speciesType\":\"2\",\"speciesClass\":\"147603\",\"speciesNomination\":\"Equus asinus\"}],\"complementParameterSet\":[{\"uniqueComplementID\":\"65b5bb8e-5b2c-4f76-ade0-472e1836c4ac\",\"complementID\":1,\"speciesID\":\"242089\",\"keyDataPair\":[{\"key\":\"number_package\",\"data\":\"1\"},{\"key\":\"number_animal\",\"data\":\"1\"}],\"identifiers\":[{\"speciesNumber\":1,\"data\":{\"microchip\":\"1\",\"passport\":\"2\"}}]}],\"includeNonAblactedAnimals\":false,\"countryOfOrigin\":\"ES\",\"animalsCertifiedAs\":\"Approved\"},\"purpose\":{\"internalMarketPurpose\":\"Rescue\",\"purposeGroup\":\"For Import\"},\"pointOfEntry\":\"GBAPHA1A\",\"arrivalDate\":\"2025-01-01\",\"arrivalTime\":\"22:00:00\",\"transporter\":{\"id\":\"ab490d10-48a7-43d8-b552-9bde3ea5ee4a\",\"type\":\"private transporter\",\"status\":\"nonapproved\",\"companyName\":\"222f0960f6884a8780472519ef042379\",\"address\":{\"addressLine1\":\"2736 Thiel Locks\",\"addressLine2\":\"Suite 332\",\"addressLine3\":\"Connecticut\",\"city\":\"Lake Estella\",\"postalZipCode\":\"71961-0\",\"countryISOCode\":\"PL\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001795},\"meansOfTransport\":{\"id\":\"2121\",\"type\":\"Railway Wagon\",\"document\":\"21\"},\"meansOfTransportFromEntryPoint\":{\"id\":\"1\",\"type\":\"Aeroplane\",\"document\":\"1\"},\"departureDate\":\"2025-02-01\",\"departureTime\":\"11:11:00\",\"estimatedJourneyTimeInMinutes\":1501,\"veterinaryInformation\":{\"accompanyingDocuments\":[{\"documentType\":\"latestVeterinaryHealthCertificate\",\"documentReference\":\"1\",\"documentIssueDate\":\"2024-01-01\"}]},\"route\":{\"transitingStates\":[\"AL\"]},\"submissionDate\":\"2024-09-03T11:45:38.561284044Z\",\"submittedBy\":{\"displayName\":\"Andrew Inspector-Tester\",\"userId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"complexCommoditySelected\":true,\"portOfEntry\":\"GBAVO\",\"isGVMSRoute\":true,\"provideCtcMrn\":\"YES\"},\"etag\":\"0000000000074C9B\",\"riskDecisionLockingTime\":\"2025-01-01T20:00:00Z\",\"isRiskDecisionLocked\":false,\"chedTypeVersion\":1}";

        var sourceNotification = new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData).Deserialize<Tdm.Types.Ipaffs.Notification>(s);
        var mappedNotification = sourceNotification.MapWithTransform();

        mappedNotification.ShouldBeEqualTo(Tdm.Model.Ipaffs.IpaffsNotificationTypeEnum.Cveda, Tdm.Model.Ipaffs.IpaffsNotificationStatusEnum.Submitted, s);
    }

    [Fact]
    public void CHEDDTest()
    {
        var s =
            "{\"id\":26574,\"referenceNumber\":\"CHEDA.GB.2024.1026574\",\"version\":1,\"lastUpdated\":\"2024-09-03T11:45:38.585822114Z\",\"lastUpdatedBy\":{\"displayName\":\"Andrew Inspector-Tester\",\"userId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"type\":\"CVEDA\",\"status\":\"SUBMITTED\",\"isHighRiskEuImport\":true,\"partOne\":{\"personResponsible\":{\"name\":\"Mark Admin-Tester\",\"companyId\":\"767ceb6a-2144-e911-a96c-000d3a29b5de\",\"companyName\":\"Defra Test BIP\",\"address\":[\"Animal and Plant Health Agency\",\"Woodham Lane\",\"New Haw\",\"Surrey\",\"Addlestone\",\"KT15 3NB\"],\"country\":\"GB\",\"tracesID\":1001,\"phone\":\"020 8225 7295\",\"email\":\"DefraTestBIP@anthunt3.33mail.com\",\"contactId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"consignor\":{\"id\":\"d5eba566-9b57-4580-84fb-d28739fa4719\",\"type\":\"exporter\",\"status\":\"nonapproved\",\"companyName\":\"c7f606df309a417da4ec442330ddd52a\",\"address\":{\"addressLine1\":\"07584 Gillian Mews\",\"addressLine2\":\"Apt. 962\",\"addressLine3\":\"Idaho\",\"city\":\"Lake Cristina\",\"postalZipCode\":\"91645\",\"countryISOCode\":\"DE\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10008591},\"consignee\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"importer\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"placeOfDestination\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"commodities\":{\"numberOfPackages\":1,\"numberOfAnimals\":1,\"commodityComplement\":[{\"commodityID\":\"0101\",\"commodityDescription\":\"Live horses, asses, mules and hinnies\",\"complementID\":1,\"complementName\":\"Equus asinus\",\"speciesID\":\"242089\",\"speciesName\":\"Equus asinus\",\"speciesType\":\"2\",\"speciesClass\":\"147603\",\"speciesNomination\":\"Equus asinus\"}],\"complementParameterSet\":[{\"uniqueComplementID\":\"65b5bb8e-5b2c-4f76-ade0-472e1836c4ac\",\"complementID\":1,\"speciesID\":\"242089\",\"keyDataPair\":[{\"key\":\"number_package\",\"data\":\"1\"},{\"key\":\"number_animal\",\"data\":\"1\"}],\"identifiers\":[{\"speciesNumber\":1,\"data\":{\"microchip\":\"1\",\"passport\":\"2\"}}]}],\"includeNonAblactedAnimals\":false,\"countryOfOrigin\":\"ES\",\"animalsCertifiedAs\":\"Approved\"},\"purpose\":{\"internalMarketPurpose\":\"Rescue\",\"purposeGroup\":\"For Import\"},\"pointOfEntry\":\"GBAPHA1A\",\"arrivalDate\":\"2025-01-01\",\"arrivalTime\":\"22:00:00\",\"transporter\":{\"id\":\"ab490d10-48a7-43d8-b552-9bde3ea5ee4a\",\"type\":\"private transporter\",\"status\":\"nonapproved\",\"companyName\":\"222f0960f6884a8780472519ef042379\",\"address\":{\"addressLine1\":\"2736 Thiel Locks\",\"addressLine2\":\"Suite 332\",\"addressLine3\":\"Connecticut\",\"city\":\"Lake Estella\",\"postalZipCode\":\"71961-0\",\"countryISOCode\":\"PL\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001795},\"meansOfTransport\":{\"id\":\"2121\",\"type\":\"Railway Wagon\",\"document\":\"21\"},\"meansOfTransportFromEntryPoint\":{\"id\":\"1\",\"type\":\"Aeroplane\",\"document\":\"1\"},\"departureDate\":\"2025-02-01\",\"departureTime\":\"11:11:00\",\"estimatedJourneyTimeInMinutes\":1501,\"veterinaryInformation\":{\"accompanyingDocuments\":[{\"documentType\":\"latestVeterinaryHealthCertificate\",\"documentReference\":\"1\",\"documentIssueDate\":\"2024-01-01\"}]},\"route\":{\"transitingStates\":[\"AL\"]},\"submissionDate\":\"2024-09-03T11:45:38.561284044Z\",\"submittedBy\":{\"displayName\":\"Andrew Inspector-Tester\",\"userId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"complexCommoditySelected\":true,\"portOfEntry\":\"GBAVO\",\"isGVMSRoute\":true,\"provideCtcMrn\":\"YES\"},\"etag\":\"0000000000074C9B\",\"riskDecisionLockingTime\":\"2025-01-01T20:00:00Z\",\"isRiskDecisionLocked\":false,\"chedTypeVersion\":1}";
        var sourceNotification = new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData).Deserialize<Tdm.Types.Ipaffs.Notification>(s);
        var mappedNotification = sourceNotification.MapWithTransform();

        mappedNotification.ShouldBeEqualTo(Tdm.Model.Ipaffs.IpaffsNotificationTypeEnum.Cveda, Tdm.Model.Ipaffs.IpaffsNotificationStatusEnum.Submitted, s);
    }

    [Fact]
    public void CHEDPPTest()
    {
        var s =
            "{\"id\":26574,\"referenceNumber\":\"CHEDA.GB.2024.1026574\",\"version\":1,\"lastUpdated\":\"2024-09-03T11:45:38.585822114Z\",\"lastUpdatedBy\":{\"displayName\":\"Andrew Inspector-Tester\",\"userId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"type\":\"CVEDA\",\"status\":\"SUBMITTED\",\"isHighRiskEuImport\":true,\"partOne\":{\"personResponsible\":{\"name\":\"Mark Admin-Tester\",\"companyId\":\"767ceb6a-2144-e911-a96c-000d3a29b5de\",\"companyName\":\"Defra Test BIP\",\"address\":[\"Animal and Plant Health Agency\",\"Woodham Lane\",\"New Haw\",\"Surrey\",\"Addlestone\",\"KT15 3NB\"],\"country\":\"GB\",\"tracesID\":1001,\"phone\":\"020 8225 7295\",\"email\":\"DefraTestBIP@anthunt3.33mail.com\",\"contactId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"consignor\":{\"id\":\"d5eba566-9b57-4580-84fb-d28739fa4719\",\"type\":\"exporter\",\"status\":\"nonapproved\",\"companyName\":\"c7f606df309a417da4ec442330ddd52a\",\"address\":{\"addressLine1\":\"07584 Gillian Mews\",\"addressLine2\":\"Apt. 962\",\"addressLine3\":\"Idaho\",\"city\":\"Lake Cristina\",\"postalZipCode\":\"91645\",\"countryISOCode\":\"DE\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10008591},\"consignee\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"importer\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"placeOfDestination\":{\"id\":\"803d26e9-ce15-4512-8d99-2b88499880fd\",\"type\":\"consignee\",\"status\":\"nonapproved\",\"companyName\":\"aa0863fc325945dcb16247e4cc242f38\",\"address\":{\"addressLine1\":\"47107 McCullough Common\",\"addressLine2\":\"Suite 139\",\"addressLine3\":\"Washington\",\"city\":\"New Dayanafurt\",\"postalZipCode\":\"35150-2\",\"countryISOCode\":\"GB\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001806},\"commodities\":{\"numberOfPackages\":1,\"numberOfAnimals\":1,\"commodityComplement\":[{\"commodityID\":\"0101\",\"commodityDescription\":\"Live horses, asses, mules and hinnies\",\"complementID\":1,\"complementName\":\"Equus asinus\",\"speciesID\":\"242089\",\"speciesName\":\"Equus asinus\",\"speciesType\":\"2\",\"speciesClass\":\"147603\",\"speciesNomination\":\"Equus asinus\"}],\"complementParameterSet\":[{\"uniqueComplementID\":\"65b5bb8e-5b2c-4f76-ade0-472e1836c4ac\",\"complementID\":1,\"speciesID\":\"242089\",\"keyDataPair\":[{\"key\":\"number_package\",\"data\":\"1\"},{\"key\":\"number_animal\",\"data\":\"1\"}],\"identifiers\":[{\"speciesNumber\":1,\"data\":{\"microchip\":\"1\",\"passport\":\"2\"}}]}],\"includeNonAblactedAnimals\":false,\"countryOfOrigin\":\"ES\",\"animalsCertifiedAs\":\"Approved\"},\"purpose\":{\"internalMarketPurpose\":\"Rescue\",\"purposeGroup\":\"For Import\"},\"pointOfEntry\":\"GBAPHA1A\",\"arrivalDate\":\"2025-01-01\",\"arrivalTime\":\"22:00:00\",\"transporter\":{\"id\":\"ab490d10-48a7-43d8-b552-9bde3ea5ee4a\",\"type\":\"private transporter\",\"status\":\"nonapproved\",\"companyName\":\"222f0960f6884a8780472519ef042379\",\"address\":{\"addressLine1\":\"2736 Thiel Locks\",\"addressLine2\":\"Suite 332\",\"addressLine3\":\"Connecticut\",\"city\":\"Lake Estella\",\"postalZipCode\":\"71961-0\",\"countryISOCode\":\"PL\",\"telephone\":\"01615555555\",\"email\":\"ukoperator@email.com\"},\"tracesId\":10001795},\"meansOfTransport\":{\"id\":\"2121\",\"type\":\"Railway Wagon\",\"document\":\"21\"},\"meansOfTransportFromEntryPoint\":{\"id\":\"1\",\"type\":\"Aeroplane\",\"document\":\"1\"},\"departureDate\":\"2025-02-01\",\"departureTime\":\"11:11:00\",\"estimatedJourneyTimeInMinutes\":1501,\"veterinaryInformation\":{\"accompanyingDocuments\":[{\"documentType\":\"latestVeterinaryHealthCertificate\",\"documentReference\":\"1\",\"documentIssueDate\":\"2024-01-01\"}]},\"route\":{\"transitingStates\":[\"AL\"]},\"submissionDate\":\"2024-09-03T11:45:38.561284044Z\",\"submittedBy\":{\"displayName\":\"Andrew Inspector-Tester\",\"userId\":\"79f6dc68-2144-e911-a96a-000d3a29ba60\"},\"complexCommoditySelected\":true,\"portOfEntry\":\"GBAVO\",\"isGVMSRoute\":true,\"provideCtcMrn\":\"YES\"},\"etag\":\"0000000000074C9B\",\"riskDecisionLockingTime\":\"2025-01-01T20:00:00Z\",\"isRiskDecisionLocked\":false,\"chedTypeVersion\":1}";

        var sourceNotification = new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData).Deserialize<Tdm.Types.Ipaffs.Notification>(s);
        var mappedNotification = sourceNotification.MapWithTransform();

        mappedNotification.ShouldBeEqualTo(Tdm.Model.Ipaffs.IpaffsNotificationTypeEnum.Cveda, Tdm.Model.Ipaffs.IpaffsNotificationStatusEnum.Submitted, s);
    }
}