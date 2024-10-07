using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Types;

public class MatchingReferenceNumber
{
    
    private MatchingReferenceNumber(string countryCode, IpaffsNotificationTypeEnum chedType, string licenceType, int year, int identifier, char? splitIdentifier)
    {
        CountryCode = countryCode;
        ChedType = chedType;
        LicenceType = licenceType;
        Year = year;
        Identifier = identifier;
        SplitIdentifier = splitIdentifier;
    }

    /*
     * <countrycode><licencetype><year>.<identifier><split indicator>
     */
    public string CountryCode { get; }

    public IpaffsNotificationTypeEnum ChedType { get; }

    public string LicenceType { get; }

    public int Year { get; }

    public int Identifier { get; }

    public char? SplitIdentifier { get; }

    public string AsCdsDocumentReference()
    {
        return $"{CountryCode}{LicenceType}{Year}.{Identifier}{SplitIdentifier}";
    }

    public string AsIpaffsReference()
    {
        return $"{ChedType.ToString().ToUpper()}.{CountryCode}.{Year}.{Identifier}{SplitIdentifier}";
    }

    public string AsYearIdentifier()
    {
        return $"{Year}.{Identifier}";
    }
    public static MatchingReferenceNumber FromCds(string reference, string documentCode)
    {
       // var reference = document.DocumentReference;

        int identifier;
        char? splitIdentifier = null;
        var parts = reference.Split(".");

        var firstPart = parts.First();

        var countryCode = firstPart.Take(2);
        var licenceType = firstPart.Skip(2).Take(3);
        var year = firstPart.Skip(5).Take(4);

        var identifierString = parts.Last();
        if (char.IsDigit(identifierString.Last()))
        {
            identifier = int.Parse(identifierString);
        }
        else
        {
            splitIdentifier = identifierString.Last();
            identifier = int.Parse(identifierString.Remove(identifierString.Length - 1));
        }
        return new MatchingReferenceNumber(
            new string(countryCode.ToArray()),
            MapToChedType(documentCode),
            new string(licenceType.ToArray()),
            int.Parse(new string(year.ToArray())),
            identifier, 
            splitIdentifier);
    }

    public static MatchingReferenceNumber FromIpaffs(string reference, IpaffsNotificationTypeEnum type)
    {
        if (reference == null)
        {
            throw new ArgumentNullException(nameof(reference));
        }

        var parts = reference.Split(".");
        int identifier;
        char? splitIdentifier = null;
        if (char.IsDigit(parts[3].Last()))
        {
            identifier = int.Parse(parts[3]);
        }
        else
        {
            splitIdentifier = parts[3].Last();
            identifier = int.Parse(parts[3].Remove(parts[3].Length - 1));
        }

        return new MatchingReferenceNumber(
            parts[1],
            type,
            MapToLicenceType(parts[0]),
            int.Parse(parts[2]), 
            identifier,
            splitIdentifier);
    }

    private static string MapToLicenceType(string chedType)
    {
        switch (chedType)
        {
            case "CHEDA": return "CHD";
            case "CHEDP": return "CHD";
        }

        return chedType;
    }

    private static IpaffsNotificationTypeEnum MapToChedType(string documentCode)
    {
        return documentCode switch
        {
            "N002" or "N851" or "9115" => IpaffsNotificationTypeEnum.Chedpp,
            "N852" or "C678" => IpaffsNotificationTypeEnum.Ced,
            "C640" => IpaffsNotificationTypeEnum.Cveda,
            "C641" or "C673"  => IpaffsNotificationTypeEnum.Cvedp
        };


    }
}