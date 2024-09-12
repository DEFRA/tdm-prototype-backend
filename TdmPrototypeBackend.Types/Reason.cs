
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Reason
{

		[EnumMember(Value = "doc-phmdm")]
		Docphmdm,
	
		[EnumMember(Value = "doc-phmdii")]
		Docphmdii,
	
		[EnumMember(Value = "doc-pa")]
		Docpa,
	
		[EnumMember(Value = "doc-pic")]
		Docpic,
	
		[EnumMember(Value = "doc-pill")]
		Docpill,
	
		[EnumMember(Value = "doc-ped")]
		Docped,
	
		[EnumMember(Value = "doc-pmod")]
		Docpmod,
	
		[EnumMember(Value = "doc-pfi")]
		Docpfi,
	
		[EnumMember(Value = "doc-pnol")]
		Docpnol,
	
		[EnumMember(Value = "doc-pcne")]
		Docpcne,
	
		[EnumMember(Value = "doc-padm")]
		Docpadm,
	
		[EnumMember(Value = "doc-padi")]
		Docpadi,
	
		[EnumMember(Value = "doc-ppni")]
		Docppni,
	
		[EnumMember(Value = "doc-pf")]
		Docpf,
	
		[EnumMember(Value = "doc-po")]
		Docpo,
	
		[EnumMember(Value = "doc-ncevd")]
		Docncevd,
	
		[EnumMember(Value = "doc-ncpqefi")]
		Docncpqefi,
	
		[EnumMember(Value = "doc-ncpqebec")]
		Docncpqebec,
	
		[EnumMember(Value = "doc-ncts")]
		Docncts,
	
		[EnumMember(Value = "doc-nco")]
		Docnco,
	
		[EnumMember(Value = "doc-orii")]
		Docorii,
	
		[EnumMember(Value = "doc-orsr")]
		Docorsr,
	
		[EnumMember(Value = "ori-orrnu")]
		Oriorrnu,
	
		[EnumMember(Value = "phy-orpp")]
		Phyorpp,
	
		[EnumMember(Value = "phy-orho")]
		Phyorho,
	
		[EnumMember(Value = "phy-is")]
		Phyis,
	
		[EnumMember(Value = "phy-orsr")]
		Phyorsr,
	
		[EnumMember(Value = "oth-cnl")]
		Othcnl,
	
		[EnumMember(Value = "oth-o")]
		Otho,
	
}


