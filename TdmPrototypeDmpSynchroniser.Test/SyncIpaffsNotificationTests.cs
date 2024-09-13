using FluentAssertions;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Models;
using static TdmPrototypeDmpSynchroniser.Api.Models.Test.SyncIpaffsNotificationTests;

namespace TdmPrototypeDmpSynchroniser.Api.Models.Test;

public class SyncIpaffsNotificationTests
{
    [Fact]
    public void ShouldDeserialise()
    {
        var s =
            "{\n    \"id\": 36543,\n    \"referenceNumber\": \"CHEDP.GB.2024.1036543\",\n    \"version\": 1,\n    \"lastUpdated\": \"2024-09-12T12:13:47.923Z\",\n    \"lastUpdatedBy\": {\n        \"displayName\": \"Mark Admin-Tester\",\n        \"userId\": \"79f6dc68-2144-e911-a96a-000d3a29ba60\"\n    },\n    \"type\": \"CVEDP\",\n    \"status\": \"SUBMITTED\",\n    \"riskAssessment\": {\n        \"commodityResults\": [\n            {\n                \"riskDecision\": \"REQUIRED\",\n                \"uniqueId\": \"49431dfe-bc23-4fb4-aa78-ad6fd8388350\"\n            }\n        ],\n        \"assessmentDateTime\": \"2024-09-12T13:13:47.894361934\"\n    },\n    \"journeyRiskCategorisation\": {\n        \"riskLevel\": \"Low\",\n        \"riskLevelMethod\": \"User\",\n        \"riskLevelDateTime\": \"2024-09-12T12:12:18.627\"\n    },\n    \"isHighRiskEuImport\": false,\n    \"partOne\": {\n        \"personResponsible\": {\n            \"name\": \"Mark Admin-Tester\",\n            \"companyId\": \"767ceb6a-2144-e911-a96c-000d3a29b5de\",\n            \"companyName\": \"Defra Test BIP\",\n            \"address\": [\n                \"Animal and Plant Health Agency\",\n                \"Woodham Lane\",\n                \"New Haw\",\n                \"Surrey\",\n                \"Addlestone\",\n                \"KT15 3NB\"\n            ],\n            \"country\": \"GB\",\n            \"tracesID\": 1001,\n            \"phone\": \"020 8225 7295\",\n            \"email\": \"DefraTestBIP@anthunt3.33mail.com\",\n            \"contactId\": \"79f6dc68-2144-e911-a96a-000d3a29ba60\"\n        },\n        \"consignor\": {\n            \"id\": \"2ab17df9-e875-4bb9-a5e9-4c9ce6c5695c\",\n            \"type\": \"exporter\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"f10888e8744d402c963c13352b53e736\",\n            \"address\": {\n                \"addressLine1\": \"53096 Murphy Station\",\n                \"addressLine2\": \"Suite 555\",\n                \"addressLine3\": \"Kansas\",\n                \"city\": \"South Ryleyview\",\n                \"postalZipCode\": \"12674\",\n                \"countryISOCode\": \"PL\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10005792\n        },\n        \"consignee\": {\n            \"id\": \"6d8f4fa7-594a-462f-9008-9a39276225ea\",\n            \"type\": \"consignee\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"4b1a8571489f43368438ffe5c148fc2a\",\n            \"address\": {\n                \"addressLine1\": \"610 Arthur Roads\",\n                \"addressLine2\": \"Suite 843\",\n                \"addressLine3\": \"Maryland\",\n                \"city\": \"Port Alvinaside\",\n                \"postalZipCode\": \"91444\",\n                \"countryISOCode\": \"GB\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10008612\n        },\n        \"importer\": {\n            \"id\": \"6d8f4fa7-594a-462f-9008-9a39276225ea\",\n            \"type\": \"importer\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"4b1a8571489f43368438ffe5c148fc2a\",\n            \"address\": {\n                \"addressLine1\": \"610 Arthur Roads\",\n                \"addressLine2\": \"Suite 843\",\n                \"addressLine3\": \"Maryland\",\n                \"city\": \"Port Alvinaside\",\n                \"postalZipCode\": \"91444\",\n                \"countryISOCode\": \"GB\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10008612\n        },\n        \"placeOfDestination\": {\n            \"id\": \"6d8f4fa7-594a-462f-9008-9a39276225ea\",\n            \"type\": \"destination\",\n            \"status\": \"nonapproved\",\n            \"companyName\": \"4b1a8571489f43368438ffe5c148fc2a\",\n            \"address\": {\n                \"addressLine1\": \"610 Arthur Roads\",\n                \"addressLine2\": \"Suite 843\",\n                \"addressLine3\": \"Maryland\",\n                \"city\": \"Port Alvinaside\",\n                \"postalZipCode\": \"91444\",\n                \"countryISOCode\": \"GB\",\n                \"telephone\": \"01615555555\",\n                \"email\": \"ukoperator@email.com\"\n            },\n            \"tracesId\": 10008612\n        },\n        \"commodities\": {\n            \"totalGrossWeight\": 3,\n            \"totalNetWeight\": 1,\n            \"numberOfPackages\": 1,\n            \"temperature\": \"Ambient\",\n            \"commodityComplement\": [\n                {\n                    \"commodityID\": \"0401\",\n                    \"commodityDescription\": \"Milk and cream, not concentrated nor containing added sugar or other sweetening matter\",\n                    \"complementID\": 1,\n                    \"complementName\": \"Camelus dromedarius\",\n                    \"speciesID\": \"106568\",\n                    \"speciesName\": \"Camelus dromedarius\",\n                    \"speciesTypeName\": \"Raw milk\",\n                    \"speciesType\": \"49\",\n                    \"speciesClass\": \"167425\",\n                    \"speciesNomination\": \"Camelus dromedarius\"\n                }\n            ],\n            \"complementParameterSet\": [\n                {\n                    \"uniqueComplementID\": \"49431dfe-bc23-4fb4-aa78-ad6fd8388350\",\n                    \"complementID\": 1,\n                    \"speciesID\": \"106568\",\n                    \"keyDataPair\": [\n                        {\n                            \"key\": \"netweight\",\n                            \"data\": \"1\"\n                        },\n                        {\n                            \"key\": \"number_package\",\n                            \"data\": \"1\"\n                        },\n                        {\n                            \"key\": \"type_package\",\n                            \"data\": \"Bale\"\n                        }\n                    ]\n                }\n            ],\n            \"includeNonAblactedAnimals\": false,\n            \"countryOfOrigin\": \"AF\",\n            \"consignedCountry\": \"AF\"\n        },\n        \"purpose\": {\n            \"conformsToEU\": true,\n            \"internalMarketPurpose\": \"Human Consumption\",\n            \"purposeGroup\": \"For Import\"\n        },\n        \"pointOfEntry\": \"GBMNC1\",\n        \"arrivalDate\": \"2024-09-13\",\n        \"arrivalTime\": \"10:00:00\",\n        \"transporterDetailsRequired\": false,\n        \"meansOfTransport\": {},\n        \"meansOfTransportFromEntryPoint\": {\n            \"id\": \"afssd\",\n            \"type\": \"Aeroplane\",\n            \"document\": \"kdfksdl\"\n        },\n        \"veterinaryInformation\": {},\n        \"submissionDate\": \"2024-09-12T12:13:46.307030992Z\",\n        \"submittedBy\": {\n            \"displayName\": \"Mark Admin-Tester\",\n            \"userId\": \"79f6dc68-2144-e911-a96a-000d3a29ba60\"\n        },\n        \"complexCommoditySelected\": true,\n        \"portOfEntry\": \"GBMAN\",\n        \"contactDetails\": {\n            \"name\": \"Mark Admin-Tester\",\n            \"telephone\": \"020 8225 7295\",\n            \"email\": \"defratestbip@anthunt3.33mail.com\"\n        },\n        \"isGVMSRoute\": false,\n        \"provideCtcMrn\": \"NO\"\n    },\n    \"partTwo\": {\n        \"decision\": {\n            \"decision\": \"Acceptable for Internal Market\",\n            \"freeCirculationPurpose\": \"Human Consumption\"\n        },\n        \"consignmentCheck\": {},\n        \"consignmentValidation\": [\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/decision/consignmentacceptable\",\n                \"message\": \"What is the decision for this consignment\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/consignmentcheck/physicalcheckdone\",\n                \"message\": \"Physical check\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/consignmentcheck/documentcheckresult\",\n                \"message\": \"Documentary check\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/laboratorytestsrequired\",\n                \"message\": \"Are laboratory tests required\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/parttwo/consignmentcheck/identitycheckdone\",\n                \"message\": \"Identity check\"\n            },\n            {\n                \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/partone/veterinaryinformation/establishmentsoforigin\",\n                \"message\": \"Approved establishment\"\n            }\n        ],\n        \"inspectionRequired\": \"Required\"\n    },\n    \"partThree\": {\n        \"sealCheckRequired\": false\n    },\n    \"consignmentValidation\": [\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/consignmentcheck/documentcheckresult\",\n            \"message\": \"Documentary check\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/consignmentcheck/identitycheckdone\",\n            \"message\": \"Identity check\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/consignmentcheck/physicalcheckdone\",\n            \"message\": \"Physical check\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/laboratorytestsrequired\",\n            \"message\": \"Are laboratory tests required\"\n        },\n        {\n            \"field\": \"uk/gov/defra/tracesx/notificationschema/representation/notification/parttwo/decision/consignmentacceptable\",\n            \"message\": \"What is the decision for this consignment\"\n        }\n    ],\n    \"etag\": \"0000000000083ED7\",\n    \"riskDecisionLockingTime\": \"2024-09-13T07:00:00Z\",\n    \"isRiskDecisionLocked\": false,\n    \"chedTypeVersion\": 1\n}";

        var n = IpaffsNotificationExtensions.FromBlob(s);
        
        
        // Unique ID should be set - need to check where the 'movement ID' is stored on the ALVS message 
       // n.Id.Should().Be("CHEDP.GB.2024.1036543");
        //n.IpaffsId.Should().Be(36543);
        n.PartOne.Commodities.CountryOfOrigin.Should().Be("AF");
        // m.Items.Length.Should().Be(2);
        // m.ClearanceRequests.Length.Should().Be(1);
        //
        // // Corrects case
        // m.ClearanceRequests.First().Header.SubmitterTurn.Should().Be("SubmitterTurn051399d7-da2e-49dc-842c-236a4e84566d");
        //     
        // // epoch parsing
        // m.ClearanceRequests.First().ServiceHeader.ServiceCallTimestamp.Should().Be(new DateTime(2024, 8, 8, 14, 39, 27));
        //
        // // Datetime parsing
        // m.ClearanceRequests.First().Header.ArrivalDateTime.Should().Be(new DateTime(2024, 8, 8, 16, 39, 27));

    }
    
    [Fact]
    public void SndExample_ShouldDeserialise()
    {
        
    }
}
