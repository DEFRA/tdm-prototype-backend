using System.ComponentModel;
using MongoDB.Bson;
using Xunit.Abstractions;

using TdmPrototypeBackend.Types;

namespace TdmPrototypeBackend.Test;

using FluentValidation.TestHelper;

[Trait("Category","Integration")]
public class CreateResourceIntegrationTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper output;
    private string testId = Guid.NewGuid().ToString();
    
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
        JsonApiConsumer.Response<Movement> response = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: CreateChedAMovement(),
            baseURI: "https://localhost:7094",
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
            baseURI: "https://localhost:7094",
            path: "api/gvmsgmrs"
        );
        
        Console.WriteLine("Response from GvmsGmr API {0}", response.ToJson());
        Assert.Equal(204, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateIpaffsNotification()
    {
        JsonApiConsumer.Response<IpaffsNotification> response = JsonApiConsumer.JsonApiConsumer.Create<IpaffsNotification, IpaffsNotification>(
            model: CreateChedANotification(),
            baseURI: "https://localhost:7094",
            path: "api/ipaffsnotifications"
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from IpaffsNotification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateChedPIpaffsNotification()
    {
        JsonApiConsumer.Response<IpaffsNotification> response = JsonApiConsumer.JsonApiConsumer.Create<IpaffsNotification, IpaffsNotification>(
            model: CreateChedANotification(notificationType: NotificationType.Cvedp),
            baseURI: "https://localhost:7094",
            path: "api/ipaffsnotifications"
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from IpaffsNotification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }

    [Fact]
    public void CreateGmrMatchedMovement()
    {
        var gmr = new GvmsGmr() { Id = "GMR" + testId, HaulierEori = "EORI", State = GvmsGmrState.NotFinalisable };

        JsonApiConsumer.Response<GvmsGmr> gmrResponse = JsonApiConsumer.JsonApiConsumer.Create<GvmsGmr, GvmsGmr>(
            model: gmr,
            baseURI: "https://localhost:7094",
            path: "api/gvmsgmrs"
        );
        
        Console.WriteLine("Response from GvmsGmr API {0}", gmrResponse.ToJson());
        
        Assert.Equal(204, (int)gmrResponse.HttpStatusCode);
        var items = new[] { new MovementItem() { CustomsProcedureCode = "AAA", Gmr = new MatchingStatus() { Matched = true, Reference = gmr.Id} } };
        var movement = CreateChedAMovement(items: items);
        // movement.Items[0].Gmr = new MatchingStatus() { Matched = true, Reference = gmr.Id};

        JsonApiConsumer.Response<Movement> crResponse = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: movement,
            baseURI: "https://localhost:7094",
            path: "api/movements"
        );
        
        Console.WriteLine("Response from Movement API {0}", crResponse.ToJson());
        
        Assert.Equal(201, (int)crResponse.HttpStatusCode);
    }
    
    [Fact]
    public void CreateMovementMatchedIpaffsNotification()
    {
        var notificationId = GenerateChedID(id: testId);
        var declarationId = GenerateDeclarationID(id: testId);

        var movement = CreateChedAMovement(declarationId);
        
        // var cr = CreateChedAClearanceRequest(declarationId);
        movement.IpaffsNotification = new MatchingStatus() { Matched = true, Reference = notificationId, AdditionalInformation = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("matchLevel", "1"),}};
        
        JsonApiConsumer.Response<Movement> crResponse = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: movement,
            baseURI: "https://localhost:7094",
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

        JsonApiConsumer.Response<IpaffsNotification> response = JsonApiConsumer.JsonApiConsumer.Create<IpaffsNotification, IpaffsNotification>(
            model: notification,
            baseURI: "https://localhost:7094",
            path: "api/ipaffsnotifications"
        );
        
        // Console.WriteLine("Response from API {code}", response.HttpStatusCode);
        Console.WriteLine("Response from IpaffsNotification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);

    }

    private Dictionary<NotificationType, string> notificationTypes = new Dictionary<NotificationType, string>()
    {
        // TODO : clarify these
        { NotificationType.Cveda, "A" },
        // { NotificationType.Ced, "C" },
        { NotificationType.Chedpp, "PP" },
        { NotificationType.Cvedp, "P" }
    };

    private string GetNotificationTypeIdSuffix(NotificationType notificationType)
    {
        return notificationTypes.ContainsKey(notificationType) ? notificationTypes[notificationType]  : "?";
    }
    
    private string GenerateChedID(NotificationType notificationType = NotificationType.Cveda, string id = null)
    {
        id = id ?? testId;
        return string.Format("CHED{0}.GB.2024.MOCK.{1}", GetNotificationTypeIdSuffix(notificationType), id);
    }
    
    private string GenerateDeclarationID(string id = null)
    {
        id = id ?? testId;
        return string.Format("DEC_GB_2024_{0}", id);
    }
    private IpaffsNotification CreateChedANotification(String id = null, NotificationType notificationType = NotificationType.Cveda)
    {
        id = id ?? GenerateChedID(notificationType, testId);
            
        return new IpaffsNotification()
        {
            Id = id,
            Version = 1,
            NotificationType = notificationType,
            PartOne = new IpaffsPartOne()
            {
                PersonResponsible = new IpaffsResponsiblePerson()
                {
                    Name = "Mr Tester",
                    CompanyId = "123",
                    CompanyName = "Test Co",
                    Country = "GB"
                    
                },
                Commodities = new[]
                {
                    new IpaffsNotificationCommodities()
                    {
                        CommodityComplement = new []{ new IpaffsNotificationCommodityComplement()
                        {   
                            CommodityID = "0101",
                            CommodityDescription = "Live horses, asses, mules and hinnies"
                        }},
                        NumberOfAnimals = 1, CountryOfOrigin = "FRA"
                    }
                },
                PointOfEntry = "GBEDI4",
                ArrivalDate = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd"),
                ArrivalTime = "11:11:00"
            }
        };
    }

    private Movement CreateChedAMovement(String id = null, MovementItem[] items = null)
    {
        id = id ?? GenerateChedID(id:testId);
        items = items ?? new[] { new MovementItem() { CustomsProcedureCode = "AAA" } };
        return new Movement()
        {
            Items = items,
            ClearanceRequests = new[] { CreateChedAClearanceRequest(id, items) }
        };
    }

    private ClearanceRequest CreateChedAClearanceRequest(String id = null, MovementItem[] items = null)
    {
        id = id ?? GenerateChedID(id:testId);
        items = items ?? new[] { new MovementItem() { CustomsProcedureCode = "AAA" } };
        return new ClearanceRequest()
        {
            // Id = id,
            ServiceHeader = new AlvsServiceHeader() { SourceSystem = "CDS", DestinationSystem = "ALVS" },
            Header = new ClearanceRequestHeader() {},
            Items = items
            
        };
    }
}