using System.Xml.Schema;
// using JsonApiConsumer;
using JsonApiConsumer;
using MongoDB.Bson;
using Serilog.Core;
using TdmPrototypeBackend.Test.Models;

// using TdmDataModel;

namespace TdmPrototypeBackend.Test;

using FluentValidation.TestHelper;

public class ClearanceRequestTests
{
    
    [Fact]
    public void CreateRequest()
    {
        var r = new ClearanceRequest() { SourceSystem = "AAA", DestinationSystem = "BBB"};

        JsonApiConsumer.Response<ClearanceRequest> response = JsonApiConsumer.JsonApiConsumer.Create<ClearanceRequest, ClearanceRequest>(
            model: r,
            baseURI: "https://localhost:7094",
            path: "clearanceRequests"
            // headers: new Dictionary<string, string>() { { "HEADER_API_KEY", "HEADER_API_KEY_VALUE" } }
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
}