//------------------------------------------------------------------------------
// <auto-generated>
	//     This code was generated from a template.
	//
	//     Manual changes to this file may cause unexpected behavior in your application.
	//     Manual changes to this file will be overwritten if the code is regenerated.
	//
//</auto-generated>
//------------------------------------------------------------------------------
#nullable enable


namespace Tdm.Types.Ipaffs;

public static class IpaffsVeterinaryInformationMapper
{
	public static Tdm.Model.Ipaffs.IpaffsVeterinaryInformation Map(Tdm.Types.Ipaffs.IpaffsVeterinaryInformation from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsVeterinaryInformation ();
to.EstablishmentsOfOriginExternalReference = IpaffsExternalReferenceMapper.Map(from?.EstablishmentsOfOriginExternalReference);
                to.EstablishmentsOfOrigins = from?.EstablishmentsOfOrigins?.Select(x => IpaffsApprovedEstablishmentMapper.Map(x)).ToArray();
                to.VeterinaryDocument = from.VeterinaryDocument;
            to.VeterinaryDocumentIssueDate = from.VeterinaryDocumentIssueDate;
            to.AccompanyingDocumentNumbers = from.AccompanyingDocumentNumbers;
            to.AccompanyingDocuments = from?.AccompanyingDocuments?.Select(x => IpaffsAccompanyingDocumentMapper.Map(x)).ToArray();
                to.CatchCertificateAttachments = from?.CatchCertificateAttachments?.Select(x => IpaffsCatchCertificateAttachmentMapper.Map(x)).ToArray();
                to.IdentificationDetails = from?.IdentificationDetails?.Select(x => IpaffsIdentificationDetailsMapper.Map(x)).ToArray();
                	return to;
	}
}

