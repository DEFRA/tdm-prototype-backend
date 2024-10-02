namespace TdmPrototypeBackend.Types;

public class MatchingReferenceNumber
{
    private MatchingReferenceNumber(string countryCode, string chedType, string licenceType, int year, int identifier, char? splitIdentifier)
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

    public string ChedType { get; }

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
        return $"{ChedType}.{CountryCode}.{Year}.{Identifier}{SplitIdentifier}";
    }
    public static MatchingReferenceNumber FromCds(string reference)
    {
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
            MapToChedType(new string(licenceType.ToArray())),
            new string(licenceType.ToArray()),
            int.Parse(new string(year.ToArray())),
            identifier, 
            splitIdentifier);
    }

    public static MatchingReferenceNumber FromIpaffs(string reference)
    {
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
            parts[0],
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

    private static string MapToChedType(string licenceType)
    {
        switch (licenceType)
        {
            case "CHD": return "CHEDP";
        }

        return licenceType;
    }
}