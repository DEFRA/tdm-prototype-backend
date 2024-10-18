using System.Collections;
using System.ComponentModel;
using MongoDB.Bson;
using Xunit.Abstractions;

using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Test;

using FluentValidation.TestHelper;

[Trait("Category","Integration")]
public class CreateResourceIntegrationTests(ITestOutputHelper output)
{
    private readonly ITestOutputHelper output;
    private string testId = Guid.NewGuid().ToString();
    private string apiHost = Environment.GetEnvironmentVariable("API_TARGET") ?? "https://localhost:3080";
    
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

    private Dictionary<string, string> GetHeaders()
    {
        // This is just a correctly formed JWT for now
        // May need updating later
        return new Dictionary<string, string>() { { "Authorization", "Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6ImZFTUh2NUE2a3lkd0tfak05M0xPYkVwYlpKWlRPRGdmTDdyT3R1Q2N6aTgifQ.eyJpZCI6IjNjZmNmZWIwLWMwZGEtNDVjMS1iYzQ0LTU0NTUxMjAyMzU1OSIsInN1YiI6IjNjZmNmZWIwLWMwZGEtNDVjMS1iYzQ0LTU0NTUxMjAyMzU1OSIsImlzcyI6Imh0dHA6Ly9jZHAtZGVmcmEtaWQtc3R1Yi5sb2NhbHRlc3QubWU6NzIwMC9jZHAtZGVmcmEtaWQtc3R1YiIsImNvcnJlbGF0aW9uSWQiOiIzNGE1YTIzZC1jNTBiLTQ5MWUtOWZlNy03NTU1MDBmYzBlNDMiLCJzZXNzaW9uSWQiOiJmZDlkZmM3Yy1kNDJkLTQ2MGUtYjMxMy1iZDk4YTdhMDkxOGQiLCJjb250YWN0SWQiOiI3M2FjMGRhZi1iOTk3LTQxNjEtOGNmMy05Mzg3OTMyYWVlZDUiLCJzZXJ2aWNlSWQiOiJjZHAtZGVmcmEtaWQtc3R1YiIsImZpcnN0TmFtZSI6IlBIQSIsImxhc3ROYW1lIjoiUkVMOTUiLCJlbWFpbCI6IlBIQVJFTDk1QGVxdWFsZXhwZXJ0cy5jb20iLCJ1bmlxdWVSZWZlcmVuY2UiOiJlYTA1ZGQ3OC1hOGRlLTQ3MWEtODhlYy05YTdmZTFhZGYyZGYiLCJsb2EiOiIxIiwiYWFsIjoiMSIsImVucm9sbWVudENvdW50IjoiMSIsImVucm9sbWVudFJlcXVlc3RDb3VudCI6IjEiLCJjdXJyZW50UmVsYXRpb25zaGlwSWQiOiJQSEEiLCJyZWxhdGlvbnNoaXBzIjoiUEhBOlJFTDk1OlBIQSBSRUw5NTowOnVuZGVmaW5lZDowIiwicm9sZXMiOiIiLCJpYXQiOjE3Mjc5NDk2Mzl9.lC26gOKnj9w0acjXQC_2P-u9vocgowoqUIb7fh9unoDT3c_bGxGGvmoLfRw07VUGQTFmmmF0XboN2m3LB_4HkZRw9F2O5IOR1kkAjExRGE59499rqL0hJh-afJtgaRGGWa-2KubrfjaGXXho8yxjsjw81okvPrhTAvbdOSUafLqJd4RBEtuVjCStaDL-mljcbF-U_IqYlnf802GDGDv53Smeh0K5ZSLX_FTD11xD6U6bx8w-eg6SF_PLE5dotG406--dlE4rgIfsopYdpMq-Og-_VPAyiozQrpLiXTZFdSMn9QhlKKcNTRaN-HtvbKaS8FpsdDhq__V6LstQP7zpiw" } };
    }
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
            path: "api/movements",
            headers: GetHeaders()
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
            path: "api/gvmsgmrs",
            headers: GetHeaders()
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
            path: "api/notifications",
            headers: GetHeaders()
        );
        
        Console.WriteLine("Response from IpaffsNotification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }
    
    [Fact]
    public void CreateChedPNotification()
    {
        JsonApiConsumer.Response<Notification> response = JsonApiConsumer.JsonApiConsumer.Create<Notification, Notification>(
            model: CreateChedANotification(notificationType: IpaffsNotificationTypeEnum.Cvedp),
            baseURI: apiHost,
            path: "api/notifications",
            headers: GetHeaders()
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
            path: "api/gvmsgmrs",
            headers: GetHeaders()
        );
        
        Console.WriteLine("Response from GvmsGmr API {0}", gmrResponse.ToJson());
        
        Assert.Equal(204, (int)gmrResponse.HttpStatusCode);
        var items = new[] { new Items() { CustomsProcedureCode = "AAA" } };
        var movement = CreateChedAMovement(items: items);
        // movement.Items[0].Gmr = new MatchingStatus() { Matched = true, Reference = gmr.Id};

        JsonApiConsumer.Response<Movement> crResponse = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: movement,
            baseURI: apiHost,
            path: "api/movements",
            headers: GetHeaders()
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
        //movement.Notifications = new List<MatchingStatus>()
        //{
        //    new MatchingStatus()
        //    {
        //        Matched = true,
        //        Reference = notificationId,
        //        AdditionalInformation =
        //            new List<KeyValuePair<string, string>>()
        //            {
        //                new KeyValuePair<string, string>("matchLevel", "1"),
        //            }
        //    }
        //};

        movement.AddRelationship("notification", new TdmRelationshipObject()
        {
            Matched = true,
            Links = RelationshipLinks.CreateForMovement(movement),
            Data = [new RelationshipDataItem()
            {
                Matched = true,
                Type = "notifications",
                Id = notificationId,
                Links = new ResourceLink() { Self = LinksBuilder.Notification.BuildSelfLink(notificationId) },
                AdditionalInformation = new Dictionary<string, string>() { { "matchingLevel", "1" } }
            }]
        });

        // var crResponse = Send<Movement>(ref movement, "api/movements");
        JsonApiConsumer.Response<Movement> crResponse = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            model: movement,
            baseURI: apiHost,
            path: "api/movements",
            headers: GetHeaders()
        );
        
        Console.WriteLine("Response from Movement API {0}", crResponse.ToJson());
        
        Assert.Equal(201, (int)crResponse.HttpStatusCode);
        
        var notification = CreateChedANotification(notificationId);
        //notification.Movements = new List<MatchingStatus>() { new MatchingStatus()
        //{
        //    Matched = true, Reference = declarationId, Item = "1",
        //    AdditionalInformation = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("matchLevel", "1")}
        //}};

        JsonApiConsumer.Response<Notification> response = JsonApiConsumer.JsonApiConsumer.Create<Notification, Notification>(
            model: notification,
            baseURI: apiHost,
            path: "api/notifications",
            headers: GetHeaders()
        );
        
        Console.WriteLine("Response from Notification API {0}", response.ToJson());
        Assert.Equal(201, (int)response.HttpStatusCode);
    }

    private Dictionary<IpaffsNotificationTypeEnum, string> notificationTypes = new Dictionary<IpaffsNotificationTypeEnum, string>()
    {
        // TODO : clarify these
        { IpaffsNotificationTypeEnum.Cveda, "A" },
        // { NotificationType.Ced, "C" },
        { IpaffsNotificationTypeEnum.Chedpp, "PP" },
        { IpaffsNotificationTypeEnum.Cvedp, "P" }
    };

    private string GetNotificationTypeIdSuffix(IpaffsNotificationTypeEnum notificationType)
    {
        return notificationTypes.ContainsKey(notificationType) ? notificationTypes[notificationType]  : "?";
    }
    
    private string GenerateChedID(IpaffsNotificationTypeEnum notificationType = IpaffsNotificationTypeEnum.Cveda, string id = null)
    {
        id = id ?? testId;
        return string.Format("CHED{0}.GB.2024.MOCK.{1}", GetNotificationTypeIdSuffix(notificationType), id);
    }
    
    private string GenerateDeclarationID(string id = null)
    {
        id = id ?? testId;
        return string.Format("DEC_GB_2024_{0}", id);
    }
    private Notification CreateChedANotification(String id = null, IpaffsNotificationTypeEnum notificationType = IpaffsNotificationTypeEnum.Cveda)
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
                        CommodityId = "0101",
                        CommodityDescription = "Live horses, asses, mules and hinnies"
                    }},
                    CountryOfOrigin = "FRA"
                },
                PointOfEntry = "GBEDI4",
                ArrivalDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7)),
                ArrivalTime = TimeOnly.Parse("11:11:00")
            }
        };
    }

    private Movement CreateChedAMovement(String id = null, Items[] items = null)
    {
        id = id ?? GenerateChedID(id:testId);
        items = items ?? new[] { new Items() { CustomsProcedureCode = "AAA" } };
        return new Movement()
        {
            Items = items.ToList(),
            ClearanceRequests = new List<ALVSClearanceRequest>() { CreateChedAClearanceRequest(id, items) }
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