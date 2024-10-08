using System.Buffers;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using FluentAssertions;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeDmpSynchroniser.Api.Models.Test;

public static class AssertExtensions
{
    public static void ShouldBe<T>(this T item, JsonElement element)
    {

        var json = JsonSerializer.Serialize(item, new JsonSerializerOptions() {  DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var actualNode = JsonNode.Parse(json);
        var expectedNode = JsonNode.Parse(element.ToString());

        var same = JsonNode.DeepEquals(actualNode, expectedNode);
        same.Should().BeTrue($"{typeof(T).Name} is not the same - expected: {expectedNode} | actual: {actualNode}");
    }

    public static void ShouldBe<T>(this T item, string expectedString)
    {

        var json = JsonSerializer.Serialize(item, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var actualNode = JsonNode.Parse(json);
        var expectedNode = JsonNode.Parse(expectedString);

        var same = JsonNode.DeepEquals(actualNode, expectedNode);
        same.Should().BeTrue($"{typeof(T).Name} is not the same - expected: {expectedNode} | actual: {actualNode}");
    }

    public static void ShouldSerializeToBson<T>(this T item)
    {
        Action act = () =>
        {
            MemoryStream ms = new MemoryStream();
            using (BsonWriter writer = new BsonBinaryWriter(ms))
            {
                BsonSerializer.Serialize(writer, item);
            }

            string data = Convert.ToBase64String(ms.ToArray());
        };


        act.Should().NotThrow("failed to serialize to Bson");
    }

    public static void ShouldBeEqualTo(this Notification notification, IpaffsNotificationTypeEnum notificationType, IpaffsNotificationStatusEnum status, string expectedJson)
    {
        IDictionary<string, object> dictionary = JsonSerializer.Deserialize<ExpandoObject>(expectedJson) as IDictionary<string, object>;

        notification.IpaffsId.Should().Be(Convert.ToInt32(dictionary["id"].ToString()));
        notification.ReferenceNumber.Should().Be(dictionary["referenceNumber"].ToString());
        notification.Version.Should().Be(Convert.ToInt32(dictionary["version"].ToString()));
        notification.LastUpdated.Should().Be(((JsonElement)dictionary["lastUpdated"]).GetDateTime());
        notification.LastUpdatedBy.ShouldBe((JsonElement)dictionary["lastUpdatedBy"]);

        notification.IpaffsType.Should().Be(notificationType);
        notification.Status.Should().Be(status);
        
       // notification.Movement.Should().NotBeNull("Movement should be set to default value");
        //notification.Movement.Matched.Should().Be(false);
        
        if (notification.RiskAssessment is not null)
        {
            notification.RiskAssessment.ShouldBe((JsonElement)dictionary["riskAssessment"]);
        }

        if (notification.JourneyRiskCategorisation is not null)
        {
            notification.JourneyRiskCategorisation.ShouldBe((JsonElement)dictionary["journeyRiskCategorisation"]);
        }

        notification.IsHighRiskEuImport.Should().Be(Convert.ToBoolean(dictionary["isHighRiskEuImport"].ToString()));

        // TODO : Deep Comparison in this way is quite brittle, causing tests to fail unecesserily.
        // Should we do something different?
        if (notification.PartOne is not null)
        {
            // ((JsonElement)dictionary["partOne"]).Deserialize<IpaffsPartOne>().ShouldBe("");
            // notification.PartOne.Consignee.CompanyName.ShouldBe(((JsonElement)dictionary["partOne"]).Deserialize<IpaffsPartOne>()!.Consignee.CompanyName);
            // notification.PartOne.ShouldBe(((JsonElement)dictionary["partOne"]).Deserialize<IpaffsPartOne>().ToJsonString());
        }
        
        if (notification.PartTwo is not null)
        {
            notification.PartTwo.ShouldBe((JsonElement)dictionary["partTwo"]);
        }
        
        if (notification.PartThree is not null)
        {   
            notification.PartThree.ShouldBe((JsonElement)dictionary["partThree"]);
        }
        

        if (notification.ConsignmentValidations is not null)
        {
            notification.ConsignmentValidations.ShouldBe((JsonElement)dictionary["consignmentValidation"]);
        }

        notification.Etag.Should().Be(dictionary["etag"].ToString());
        notification.RiskDecisionLockingTime.Should().Be(((JsonElement)dictionary["riskDecisionLockingTime"]).GetDateTime());
        notification.IsRiskDecisionLocked.Should().Be(Convert.ToBoolean(dictionary["isRiskDecisionLocked"].ToString()));
        notification.ChedTypeVersion.Should().Be(Convert.ToInt32(dictionary["chedTypeVersion"].ToString()));

        notification.ShouldSerializeToBson();
    }

}