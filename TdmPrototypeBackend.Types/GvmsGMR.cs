﻿using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

public enum GvmsGmrState
{
    NotFinalisable = 1
}

[Resource]
public class GvmsGmr : CustomStringMongoIdentifiable
{
    // This field is used by the jsonapi-consumer to control the correct casing in the type field 
    public string Type { get; set; } = "gvmsGmrs";
    
    // [Attr]
    // public string GmrId { get; set; } = default!;

    [Attr]
    public string HaulierEori { get; set; } = default!;
    
    [Attr]
    public GvmsGmrState State { get; set; } = default!;

    // public ClearanceRequestItem[] Items = [];

}