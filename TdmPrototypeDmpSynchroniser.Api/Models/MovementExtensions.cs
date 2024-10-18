using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeDmpSynchroniser.Api.SensitiveData;
using ALVSClearanceRequest = TdmPrototypeBackend.Types.Alvs.AlvsClearanceRequest;
using Type = System.Type;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class MovementExtensions
{
    public static Movement FromClearanceRequest(string s, ISensitiveDataSerializer sensitiveDataSerializer)
    {
        var r = ClearanceRequestExtensions.FromBlob(s, sensitiveDataSerializer);
       
        return new Movement() {
            Id = r.Header!.EntryReference,
            LastUpdated = r.ServiceHeader?.ServiceCallTimestamp,
            EntryReference = r.Header.EntryReference,
            MasterUCR = r.Header.MasterUCR,
            // DeclarationPartNumber = ConvertInt(r.Header.DeclarationPartNumber),
            DeclarationType = r.Header.DeclarationType,
            // ArrivalDateTime = r.Header.ArrivalDateTime,
            SubmitterTURN = r.Header.SubmitterTURN,
            DeclarantId = r.Header.DeclarantId,
            DeclarantName = r.Header.DeclarantName,
            DispatchCountryCode = r.Header.DispatchCountryCode,
            GoodsLocationCode = r.Header.GoodsLocationCode,
            ClearanceRequests = new List<ALVSClearanceRequest>()
            {
                r
            },
            Items = r.Items?.Select(x =>
            {
                x.ClearanceRequestReference = r.Header.EntryReference;
                return x;
            }).ToList(),
        };
    }
}