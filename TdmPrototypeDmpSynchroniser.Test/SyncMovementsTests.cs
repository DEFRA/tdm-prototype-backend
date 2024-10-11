using System.Text.Json.Serialization;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Storage.Mongo;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.SensitiveData;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Api.Models.Test;

public class SyncMovementsTests
{

    [Fact]
    public async Task SyncMovement_WhenVersionHasChanged_AuditEntriesShouldBeCreated()
    {
        var existingItem =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1619550176000},\"header\":{\"entryReference\":\"21GB3U0G9F0ZAPSFR9\",\"entryVersionNumber\":1,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":null,\"submitterTURN\":\"GB363127805000\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"0204423010\",\"goodsDescription\":\"LAMB\",\"consigneeId\":\"GB782435121000\",\"consigneeName\":\"GB782435121000\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"CHEDP.GB.2021.1076308\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";


        var newItem =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1619550176000},\"header\":{\"entryReference\":\"21GB3U0G9F0ZAPSFR9\",\"entryVersionNumber\":2,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":null,\"submitterTURN\":\"GB363127805001\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"0204423011\",\"goodsDescription\":\"LAMB\",\"consigneeId\":\"GB782435121001\",\"consigneeName\":\"GB782435121001\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"CHEDP.GB.2021.1076308\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";

        IConfiguration config = new ConfigurationBuilder().Build();
        Mock<IBlobService> blobService = new Mock<IBlobService>();
        Mock<IStorageService<Movement>> movementService = new Mock<IStorageService<Movement>>();
        Mock<IStorageService<Notification>> notificationService = new Mock<IStorageService<Notification>>();
        var syncService = new SyncService(new NullLoggerFactory(), new SynchroniserConfig(config), blobService.Object,
            movementService.Object, notificationService.Object, null, new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData));

        string path = "RAW/ALVS/";

        blobService.Setup(x => x.GetResourcesAsync(path))
            .ReturnsAsync(new List<IBlobItem>() { new SynchroniserBlobItem() { Name = "Item1", Content = newItem } });

        blobService.Setup(x => x.GetBlobAsync("Item1"))
            .ReturnsAsync(new SynchroniserBlobItem() { Name = "Item1", Content = newItem });

        movementService.Setup(x => x.Find("21GB3U0G9F0ZAPSFR9")).ReturnsAsync(
            MovementExtensions.FromClearanceRequest(existingItem, new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData)));
        await syncService.SyncMovements(SyncPeriod.All);


        movementService.Verify(x => x.Upsert(It.Is<Movement>(x => x.AuditEntries.Count == 1)));


    }

    [Fact]
    public async Task SyncMovement_WhenVersionHasNotChanged_AuditEntriesShouldNotBeCreated()
    {

        var existingItem =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1619550176000},\"header\":{\"entryReference\":\"21GB3U0G9F0ZAPSFR9\",\"entryVersionNumber\":1,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":null,\"submitterTURN\":\"GB363127805000\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"0204423010\",\"goodsDescription\":\"LAMB\",\"consigneeId\":\"GB782435121000\",\"consigneeName\":\"GB782435121000\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"CHEDP.GB.2021.1076308\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";


        var newItem =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1619550176000},\"header\":{\"entryReference\":\"21GB3U0G9F0ZAPSFR9\",\"entryVersionNumber\":1,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":null,\"submitterTURN\":\"GB363127805000\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"0204423010\",\"goodsDescription\":\"LAMB\",\"consigneeId\":\"GB782435121000\",\"consigneeName\":\"GB782435121000\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"CHEDP.GB.2021.1076308\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";

        IConfiguration config = new ConfigurationBuilder().Build();
        Mock<IBlobService> blobService = new Mock<IBlobService>();
        Mock<IStorageService<Movement>> movementService = new Mock<IStorageService<Movement>>();
        Mock<IStorageService<Notification>> notificationService = new Mock<IStorageService<Notification>>();
        var syncService = new SyncService(new NullLoggerFactory(), new SynchroniserConfig(config), blobService.Object,
            movementService.Object, notificationService.Object, null, new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData));

        string path = "RAW/ALVS/";

        blobService.Setup(x => x.GetResourcesAsync(path))
            .ReturnsAsync(new List<IBlobItem>() { new SynchroniserBlobItem() { Name = "Item1", Content = newItem } });

        blobService.Setup(x => x.GetBlobAsync("Item1"))
            .ReturnsAsync(new SynchroniserBlobItem() { Name = "Item1", Content = newItem });

        movementService.Setup(x => x.Find("21GB3U0G9F0ZAPSFR9")).ReturnsAsync(
            MovementExtensions.FromClearanceRequest(existingItem, new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData)));
        await syncService.SyncMovements(SyncPeriod.All);

        

        movementService.Verify(x => x.Upsert(It.IsAny<Movement>()), Times.Never);


    }

    [Fact]
    public async Task SyncMovement_NoPreviousVersionExists_AuditEntriesShouldNotBeCreated()
    {

        var newItem =
            "{\"serviceHeader\":{\"sourceSystem\":\"CDS\",\"destinationSystem\":\"ALVS\",\"correlationId\":\"20\",\"serviceCallTimestamp\":1619550176000},\"header\":{\"entryReference\":\"21GB3U0G9F0ZAPSFR9\",\"entryVersionNumber\":1,\"previousVersionNumber\":1,\"declarationUCR\":\"1GB782435121000-000000001079849\",\"declarationPartNumber\":null,\"declarationType\":\"F\",\"arrivalDateTime\":null,\"submitterTURN\":\"GB363127805000\",\"declarantId\":\"GB363127805000\",\"declarantName\":\"GB363127805000\",\"dispatchCountryCode\":\"GB\",\"goodsLocationCode\":\"BELBELGVM\",\"masterUCR\":null},\"items\":[{\"itemNumber\":1,\"customsProcedureCode\":\"4000000\",\"taricCommodityCode\":\"0204423010\",\"goodsDescription\":\"LAMB\",\"consigneeId\":\"GB782435121000\",\"consigneeName\":\"GB782435121000\",\"itemNetMass\":14910.75,\"itemSupplementaryUnits\":0,\"itemThirdQuantity\":null,\"itemOriginCountryCode\":\"NZ\",\"documents\":[{\"documentCode\":\"N853\",\"documentReference\":\"CHEDP.GB.2021.1076308\",\"documentStatus\":\"AE\",\"documentControl\":\"P\",\"documentQuantity\":null}],\"checks\":[{\"checkCode\":\"H234\",\"departmentCode\":\"PHA\"}]}]}";

        IConfiguration config = new ConfigurationBuilder().Build();
        Mock<IBlobService> blobService = new Mock<IBlobService>();
        Mock<IStorageService<Movement>> movementService = new Mock<IStorageService<Movement>>();
        Mock<IStorageService<Notification>> notificationService = new Mock<IStorageService<Notification>>();
        var syncService = new SyncService(new NullLoggerFactory(), new SynchroniserConfig(config), blobService.Object,
            movementService.Object, notificationService.Object, null, new SensitiveDataSerializer(SensitiveDataOptions.WithSensitiveData));

        string path = "RAW/ALVS/";

        blobService.Setup(x => x.GetResourcesAsync(path))
            .ReturnsAsync(new List<IBlobItem>() { new SynchroniserBlobItem() { Name = "Item1", Content = newItem } });

        blobService.Setup(x => x.GetBlobAsync("Item1"))
            .ReturnsAsync(new SynchroniserBlobItem() { Name = "Item1", Content = newItem });

        
        await syncService.SyncMovements(SyncPeriod.All);

        movementService.Verify(x => x.Upsert(It.Is<Movement>(
            x => x.AuditEntries.Count == 1)));
        
    }
}