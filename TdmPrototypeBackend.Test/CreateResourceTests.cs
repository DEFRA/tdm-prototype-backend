using System.Xml.Schema;
// using JsonApiConsumer;
using JsonApiConsumer;
using MongoDB.Bson;
using Serilog.Core;
// using TdmPrototypeBackend.Test.Models;

using TdmPrototypeBackend.Types;

namespace TdmPrototypeBackend.Test;

using FluentValidation.TestHelper;

public class CreateResourceTests
{
    
    [Fact]
    public void CreateClearanceRequest()
    {
        var r = new ClearanceRequest() { SourceSystem = "AAA", DestinationSystem = "BBB"};

        JsonApiConsumer.Response<ClearanceRequest> response = JsonApiConsumer.JsonApiConsumer.Create<ClearanceRequest, ClearanceRequest>(
            model: r,
            baseURI: "https://localhost:7094",
            path: "clearancerequests"
            // headers: new Dictionary<string, string>() { { "HEADER_API_KEY", "HEADER_API_KEY_VALUE" } }
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateGvmsGmr()
    {
        var r = new GvmsGmr() { GmrId = "123", HaulierEori = "EORI", State = GvmsGmrState.NotFinalisable };

        JsonApiConsumer.Response<GvmsGmr> response = JsonApiConsumer.JsonApiConsumer.Create<GvmsGmr, GvmsGmr>(
            model: r,
            baseURI: "https://localhost:7094",
            path: "gvmsgmrs"
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateIpaffsNotification()
    {
        var r = new IpaffsNotification() { ReferenceNumber  = "123", IpaffsID = 1, Version = 1 };

        JsonApiConsumer.Response<IpaffsNotification> response = JsonApiConsumer.JsonApiConsumer.Create<IpaffsNotification, IpaffsNotification>(
            model: r,
            baseURI: "https://localhost:7094",
            path: "ipaffsnotifications"
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
}