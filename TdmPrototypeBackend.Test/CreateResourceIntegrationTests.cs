using System.Collections;
using System.ComponentModel;
using MongoDB.Bson;
using Xunit.Abstractions;

using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Test;

using FluentValidation.TestHelper;

[Trait("Category","Integration")]
public class CreateResourceIntegrationTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper output;
    private string testId = Guid.NewGuid().ToString();
    private string apiHost = Environment.GetEnvironmentVariable("API_TARGET") ?? "https://localhost:7094";
    
    // [Fact]
    // public void CreateClearanceRequest()
    // {
    //     JsonApiConsumer.Response<ClearanceRequest> response = JsonApiConsumer.JsonApiConsumer.Create<ClearanceRequest, ClearanceRequest>(
    //         model: CreateChedAClearanceRequest(),
    //         baseURI: "https://localhost:7094",
    //         path: "api/clearancerequests"
    //     );
    //     
    //     Console.WriteLine("Response from ClearanceRequest API {0}", response.ToJson());
    //     Assert.Equal(201, (int)response.HttpStatusCode);
    // }
    
    [Fact]
    public void CreateMovement()
    {
        
        foreach(DictionaryEntry e in System.Environment.GetEnvironmentVariables())
        {
            Console.WriteLine(e.Key  + ":" + e.Value);
        }
        
        JsonApiConsumer.Response<Movement> response = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: CreateChedAMovement(),
            baseURI: apiHost,
            path: "api/movements"
        );
        
        Console.WriteLine("Response from Movement API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateGvmsGmr()
    {
        var r = new GvmsGmr() { Id = "GMR" + testId, HaulierEori = "EORI", State = GvmsGmrState.NotFinalisable };

        JsonApiConsumer.Response<GvmsGmr> response = JsonApiConsumer.JsonApiConsumer.Create<GvmsGmr, GvmsGmr>(
            model: r,
            baseURI: apiHost,
            path: "api/gvmsgmrs"
        );
        
        Console.WriteLine("Response from GvmsGmr API {0}", response.ToJson());
        Assert.Equal(204, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateNotification()
    {
        JsonApiConsumer.Response<Notification> response = JsonApiConsumer.JsonApiConsumer.Create<Notification, Notification>(
            model: CreateChedANotification(),
            baseURI: apiHost,
            path: "api/notifications"
        );
        
        Console.WriteLine("Response from IpaffsNotification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateChedPNotification()
    {
        JsonApiConsumer.Response<Notification> response = JsonApiConsumer.JsonApiConsumer.Create<Notification, Notification>(
            model: CreateChedANotification(notificationType: IpaffsIpaffsNotificationTypeEnum.Cvedp),
            baseURI: apiHost,
            path: "api/notifications"
        );
        
        Console.WriteLine("Response from notification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }

    [Fact]
    public void CreateGmrMatchedMovement()
    {
        var gmr = new GvmsGmr() { Id = "GMR" + testId, HaulierEori = "EORI", State = GvmsGmrState.NotFinalisable };

        JsonApiConsumer.Response<GvmsGmr> gmrResponse = JsonApiConsumer.JsonApiConsumer.Create<GvmsGmr, GvmsGmr>(
            model: gmr,
            baseURI: apiHost,
            path: "api/gvmsgmrs"
        );
        
        Console.WriteLine("Response from GvmsGmr API {0}", gmrResponse.ToJson());
        
        Assert.Equal(204, (int)gmrResponse.HttpStatusCode);
        var items = new[] { new Items() { CustomsProcedureCode = "AAA" } };
        var movement = CreateChedAMovement(items: items);
        // movement.Items[0].Gmr = new MatchingStatus() { Matched = true, Reference = gmr.Id};

        JsonApiConsumer.Response<Movement> crResponse = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: movement,
            baseURI: apiHost,
            path: "api/movements"
        );
        
        Console.WriteLine("Response from Movement API {0}", crResponse.ToJson());
        
        Assert.Equal(201, (int)crResponse.HttpStatusCode);
    }
    
    [Fact]
    public void CreateMovementMatchedNotification()
    {
        var notificationId = GenerateChedID(id: testId);
        var declarationId = GenerateDeclarationID(id: testId);

        var movement = CreateChedAMovement(declarationId);
        
        // var cr = CreateChedAClearanceRequest(declarationId);
        movement.Notification = new MatchingStatus() { Matched = true, Reference = notificationId, AdditionalInformation = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("matchLevel", "1"),}};
        
        // var crResponse = Send<Movement>(ref movement, "api/movements");
        JsonApiConsumer.Response<Movement> crResponse = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: movement,
            baseURI: apiHost,
            path: "api/movements"
        );
        
        Console.WriteLine("Response from Movement API {0}", crResponse.ToJson());
        
        Assert.Equal(201, (int)crResponse.HttpStatusCode);
        
        var notification = CreateChedANotification(notificationId);
        notification.Movement = new MatchingStatus()
        {
            Matched = true, Reference = declarationId, Item = 1,
            AdditionalInformation = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("matchLevel", "1")}
        };

        JsonApiConsumer.Response<Notification> response = JsonApiConsumer.JsonApiConsumer.Create<Notification, Notification>(
            model: notification,
            baseURI: apiHost,
            path: "api/notifications"
        );
        
        Console.WriteLine("Response from Notification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }

    private Dictionary<IpaffsIpaffsNotificationTypeEnum, string> notificationTypes = new Dictionary<IpaffsIpaffsNotificationTypeEnum, string>()
    {
        // TODO : clarify these
        { IpaffsIpaffsNotificationTypeEnum.Cveda, "A" },
        // { NotificationType.Ced, "C" },
        { IpaffsIpaffsNotificationTypeEnum.Chedpp, "PP" },
        { IpaffsIpaffsNotificationTypeEnum.Cvedp, "P" }
    };

    private string GetNotificationTypeIdSuffix(IpaffsIpaffsNotificationTypeEnum notificationType)
    {
        return notificationTypes.ContainsKey(notificationType) ? notificationTypes[notificationType]  : "?";
    }
    
    private string GenerateChedID(IpaffsIpaffsNotificationTypeEnum notificationType = IpaffsIpaffsNotificationTypeEnum.Cveda, string id = null)
    {
        id = id ?? testId;
        return string.Format("CHED{0}.GB.2024.MOCK.{1}", GetNotificationTypeIdSuffix(notificationType), id);
    }
    
    private string GenerateDeclarationID(string id = null)
    {
        id = id ?? testId;
        return string.Format("DEC_GB_2024_{0}", id);
    }
    private Notification CreateChedANotification(String id = null, IpaffsIpaffsNotificationTypeEnum notificationType = IpaffsIpaffsNotificationTypeEnum.Cveda)
    {
        id = id ?? GenerateChedID(notificationType, testId);
            
        return new Notification()
        {
            Id = id,
            // ReferenceNumber = id,
            Version = 1,
            IpaffsType = notificationType,
            PartOne = new IpaffsPartOne()
            {
                PersonResponsible = new  IpaffsParty()
                {
                    Name = "Mr Tester",
                    CompanyId = "123",
                    CompanyName = "Test Co",
                    Country = "GB"
                    
                },
                Commodities = new  IpaffsCommodities()
                {
                    CommodityComplements =  new []{ new IpaffsCommodityComplement()
                    {   
                        CommodityID = "0101",
                        CommodityDescription = "Live horses, asses, mules and hinnies"
                    }},
                    CountryOfOrigin = "FRA"
                },
                PointOfEntry = "GBEDI4",
                ArrivalDate = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd"),
                ArrivalTime = "11:11:00"
            }
        };
    }

    private Movement CreateChedAMovement(String id = null, Items[] items = null)
    {
        id = id ?? GenerateChedID(id:testId);
        items = items ?? new[] { new Items() { CustomsProcedureCode = "AAA" } };
        return new Movement()
        {
            Items = items,
            ClearanceRequests = new[] { CreateChedAClearanceRequest(id, items) }
        };
    }

    private ALVSClearanceRequest CreateChedAClearanceRequest(String id = null, Items[] items = null)
    {
        id = id ?? GenerateChedID(id:testId);
        items = items ?? new[] { new Items() { CustomsProcedureCode = "AAA" } };
        return new ALVSClearanceRequest()
        {
            // Id = id,
            ServiceHeader = new ServiceHeader() { SourceSystem = "CDS", DestinationSystem = "ALVS" },
            Header = new  Header() {},
            Items = items.Select(x => new Items() { CustomsProcedureCode = x.CustomsProcedureCode}).ToArray()
            
        };
    }
}