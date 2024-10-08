using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeCdsSimulator.Extensions;

public static class ALVSClearanceRequestBuilder
{
    private static readonly char[] s_AlphaNumeric = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static ALVSClearanceRequest BuildFromNotification(Notification notification)
    {
        return notification.IpaffsType switch
        {
            IpaffsNotificationTypeEnum.Cveda => Build(notification, "C640"),
            IpaffsNotificationTypeEnum.Cvedp => Build(notification, "N853"),
            IpaffsNotificationTypeEnum.Chedpp => Build(notification, "N851"),
            IpaffsNotificationTypeEnum.Ced => Build(notification, "C678"),
            IpaffsNotificationTypeEnum.Imp => Build(notification, "N002"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static string GenerateRandomString(int characters = 14)
    {
        return new string(new Random().GetItems(s_AlphaNumeric, characters));
    }


    private static ALVSClearanceRequest Build(Notification notification, string documentCode)
    {
        const string declarant = "GB363127805000";
        var now = DateTime.UtcNow;
        ALVSClearanceRequest clearanceRequest = new ALVSClearanceRequest();
        clearanceRequest.Header = new Header()
        {
            EntryReference = $"{now.ToString("yy")}GB{GenerateRandomString()}",
            EntryVersionNumber = 2,
            DeclarationUCR = $"Sim{notification.Id}",
            MasterUCR = $"Sim{notification.Id}",
            DeclarantName = "CDS_Simulator",
            PreviousVersionNumber = 1,
            GoodsLocationCode = "BELBELGVM",

        };

        clearanceRequest.ServiceHeader = new ServiceHeader()
        {
            ServiceCallTimestamp = now,
            SourceSystem = "CDSSIM",
            DestinationSystem = "ALVS",
            CorrelationId = "000"
        };

        var document = new Document()
        {
            DocumentReference =
                MatchingReferenceNumber.FromIpaffs(notification.Id, notification.IpaffsType.Value)
                    .AsCdsDocumentReference(),
            DocumentCode = documentCode,
            DocumentQuantity = 3,
            DocumentStatus = "P"
        };

        var commodities = notification!.PartOne!.Commodities!;

        clearanceRequest.Items = commodities.CommodityComplements!
            .Select((c, index) => new Items()
            {
                ItemNumber = index + 1,
                TaricCommodityCode = c.CommodityID!.PadRight(10, '0'),
                GoodsDescription = c.CommodityDescription, //from notification
                ItemOriginCountryCode = commodities.CountryOfOrigin,
                ItemSupplementaryUnits = c.AdditionalData!.ContainsKey("numberAnimal") ? decimal.Parse(c.AdditionalData["numberAnimal"].ToString()!) : 0, //Number animals
                ItemNetMass = c.AdditionalData!.ContainsKey("numberAnimal") ? 0 : 1000, //from notification, 0 if animals
                Documents = new[]
                {
                    document
                },
                Checks = new Check[1] { new() { CheckCode = "H2019", DepartmentCode = "GB" } }
            }).ToArray();

        return clearanceRequest;
    }
}