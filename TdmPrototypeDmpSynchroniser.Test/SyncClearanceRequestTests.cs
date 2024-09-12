using FluentAssertions;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Models.Test;

public class SyncClearanceRequestTests
{
    [Fact]
    public void ShouldDeserialise()
    {
        var s =
            "{\"ServiceHeader\":{\"SourceSystem\":\"IPAFFS\",\"DestinationSystem\":\"ALVS\",\"CorrelationId\":\"773207816\",\"ServiceCallTimestamp\":\"1723127967\"},\"Header\":{\"EntryReference\":\"ALVSCDSSTAND1094395\",\"EntryVersionNumber\":1,\"PreviousVersionNumber\":0,\"DeclarationUCR\":\"DeclarationUcr11dff8fb-013f-4f25-9deb-4b7fc4dba73f\",\"DeclarationPartNumber\":\"DeclarationPartNumber6bf362f9-cb6e-425f-9c43-fac3ebf1de4a\",\"DeclarationType\":\"DeclarationTypeb1e54f90-3cf5-4550-aa34-0a943f000b33\",\"ArrivalDateTime\":\"8/8/2024 4:39:27\u202fPM\",\"SubmitterTURN\":\"SubmitterTurn051399d7-da2e-49dc-842c-236a4e84566d\",\"DeclarantId\":\"DeclarantId1903afb4-db43-4661-817b-a5c0a868626c\",\"DeclarantName\":\"DeclarantName5263ec65-99f7-44b0-b29c-a16ba7e0791c\",\"DispatchCountryCode\":\"DispatchCountryCode20ac9d97-2dd9-4ed5-8722-98ce86c05943\",\"GoodsLocationCode\":\"ABDABDABDGVM\",\"MasterUCR\":\"MasterUcrf0be5d5d-0259-4fee-82b8-6e654c3e45c8\"},\"Items\":[{\"ItemNumber\":1445403,\"CustomsProcedureCode\":\"CustomsProcedureCode56b17987-0deb-4ff7-b5f3-04a135c4c019\",\"TaricCommodityCode\":\"123456789\",\"GoodsDescription\":\"GoodsDescriptionc5093fe6-4049-47a4-8bca-731d6d9fd910\",\"ConsigneeId\":\"ConsigneeId3a6ff105-95d8-4c54-9689-777577e75f16\",\"ConsigneeName\":\"ConsigneeNamec2f8d944-f1af-424c-b019-cb218ca6b9cf\",\"ItemNetMass\":\"ItemNetMass8c9e4541-08ce-4779-8570-9fce17dc0c10\",\"ItemSupplementaryUnits\":\"ItemSupplementaryUnits642e1c87-92c2-4384-b01d-97ac611d42ba\",\"ItemThirdQuantity\":\"ItemThirdQuantity777ca7a5-f0f8-4400-bb18-59321e0002b7\",\"ItemOriginCountryCode\":\"ItemOriginCountryCode181651eb-1c6a-4a55-893d-f11a1cdcb9f2\",\"Documents\":[{\"DocumentCode\":\"C640\",\"DocumentReference\":\"GBCVD2024.1094395\"}],\"AlvsRequestCheck\":[]},{\"ItemNumber\":8986773,\"CustomsProcedureCode\":\"CustomsProcedureCodec014b017-c464-4094-9eda-52c3d43450c9\",\"TaricCommodityCode\":\"TaricCommodityCode63c18a48-cd66-4990-9df4-0fb33ca94ac1\",\"GoodsDescription\":\"GoodsDescription6ce356e9-da37-4c7b-87a2-adb4488f7995\",\"ConsigneeId\":\"ConsigneeId61ec0bbb-92d2-49db-a9cd-34a909fcbdc3\",\"ConsigneeName\":\"ConsigneeName679f8e36-ed6e-49bf-a0ad-38c9e2bf811a\",\"ItemNetMass\":\"ItemNetMassd1e823ff-50d6-4334-abb6-7c84308664d3\",\"ItemSupplementaryUnits\":\"ItemSupplementaryUnits6ede2a59-7801-47e0-b504-4235e905061a\",\"ItemThirdQuantity\":\"ItemThirdQuantity4ed143c0-8ac5-4b1c-8465-7239dc12adb9\",\"ItemOriginCountryCode\":\"ItemOriginCountryCode42c9a82c-8e60-443b-967a-5cd71e8c900b\",\"Documents\":[{\"DocumentCode\":\"C640\",\"DocumentReference\":\"GBCVD2024.8231615\"}],\"AlvsRequestCheck\":[]}]}";

        var m = MovementExtensions.FromClearanceRequest(s);
        
        
        // Unique ID should be set - need to check where the 'movement ID' is stored on the ALVS message 
        m.Id.Should().Be("ALVSCDSSTAND1094395");
        m.Items.Length.Should().Be(2);
        m.ClearanceRequests.Length.Should().Be(1);
        
        // Corrects case
        m.ClearanceRequests.First().Header.SubmitterTurn.Should().Be("SubmitterTurn051399d7-da2e-49dc-842c-236a4e84566d");
            
        // epoch parsing
        m.ClearanceRequests.First().ServiceHeader.ServiceCallTimestamp.Should().Be(new DateTime(2024, 8, 8, 14, 39, 27));
        
        // Datetime parsing
        m.ClearanceRequests.First().Header.ArrivalDateTime.Should().Be(new DateTime(2024, 8, 8, 16, 39, 27));

    }
    
    [Fact]
    public void SndExample_ShouldDeserialise()
    {
        var s =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1712851200000},\"header\":{\"entryReference\":\"CHEDPGB20241036190\",\"entryVersionNumber\":2,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":\"202309100911\",\"submitterTURN\":\"GB363127805000\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"1702401000\",\"goodsDescription\":\"Other\",\"consigneeId\":\"GB782435121000\",\"consigneeName\":\"GB782435121000\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"GBCHD2024.1036190\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";

        var m = MovementExtensions.FromClearanceRequest(s);
        
        
        // Unique ID should be set - need to check where the 'movement ID' is stored on the ALVS message 
        m.Id.Should().Be("CHEDPGB20241036190");
        m.Items.Length.Should().Be(1);
        m.ClearanceRequests.Length.Should().Be(1);
    }
    
    [Fact]
    public void SndExample_ShouldDeserialise()
    {
        var s =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1712851200000},\"header\":{\"entryReference\":\"CHEDPGB20241036190\",\"entryVersionNumber\":2,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":\"202309100911\",\"submitterTURN\":\"GB363127805000\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"1702401000\",\"goodsDescription\":\"Other\",\"consigneeId\":\"GB782435121000\",\"consigneeName\":\"GB782435121000\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"GBCHD2024.1036190\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";

        var m = MovementExtensions.FromClearanceRequest(s);
        
        
        // Unique ID should be set - need to check where the 'movement ID' is stored on the ALVS message 
        m.Id.Should().Be("MasterUcrf0be5d5d-0259-4fee-82b8-6e654c3e45c8");
        m.Items.Length.Should().Be(2);
        m.ClearanceRequests.Length.Should().Be(1);
        
        // Corrects case
        m.ClearanceRequests.First().Header.SubmitterTurn.Should().Be("SubmitterTurn051399d7-da2e-49dc-842c-236a4e84566d");
            
        // epoch parsing
        m.ClearanceRequests.First().ServiceHeader.ServiceCallTimestamp.Should().Be(new DateTime(2024, 8, 8, 14, 39, 27));
        
        // Datetime parsing
        m.ClearanceRequests.First().Header.ArrivalDateTime.Should().Be(new DateTime(2024, 8, 8, 16, 39, 27));

    }
    
    
}