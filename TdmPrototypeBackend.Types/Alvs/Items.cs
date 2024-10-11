//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using System.Dynamic;


namespace TdmPrototypeBackend.Types.Alvs;

public partial class Items  //
{
    /// <summary>
    /// 
    /// </summary>
    [Attr]
    [JsonPropertyName("clearanceRequestReference")]
    public string? ClearanceRequestReference { get; set; }


    public void MergeChecks(Items decisionItems)
    {
        var checks = this.Checks?.ToList();
        if (checks == null)
        {
            checks = new List<Check>();
        }

        foreach (var decisionItemsCheck in decisionItems.Checks)
        {
            var existing = checks.Find(x => x.CheckCode == decisionItemsCheck.CheckCode);
            if (existing != null)
            {
                existing.DecisionCode = decisionItemsCheck.DecisionCode;
                existing.DecisionReasons = decisionItemsCheck.DecisionReasons;
                existing.DecisionsValidUntil = decisionItemsCheck.DecisionsValidUntil;
                existing.DepartmentCode = decisionItemsCheck.DepartmentCode;
            }
            else
            {
                checks.Add(decisionItemsCheck);
            }
        }

        this.Checks = checks.ToArray();
    }

   
}


