using FluentAssertions;
using TdmPrototypeBackend.Types;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test;

public class MatchingReferenceNumberTests(ITestOutputHelper output)
{
    [Fact]
    public void ReferenceNumber_FromIpaffs_NoSplitIndicator()
    {
        var referenceNumber = MatchingReferenceNumber.FromIpaffs("CHEDP.GB.2024.1036543");

        referenceNumber.ChedType.Should().Be("CHEDP");
        referenceNumber.LicenceType.Should().Be("CHD");
        referenceNumber.CountryCode.Should().Be("GB");
        referenceNumber.Identifier.Should().Be(1036543);
        referenceNumber.Year.Should().Be(2024);
        referenceNumber.SplitIdentifier.Should().BeNull();
        referenceNumber.AsCdsDocumentReference().Should().Be("GBCHD2024.1036543");
        referenceNumber.AsIpaffsReference().Should().Be("CHEDP.GB.2024.1036543");
        referenceNumber.AsYearIdentifier().Should().Be("2024.1036543");
    }

    [Fact]
    public void ReferenceNumber_FromIpaffs_HasSplitIndicator()
    {
        var referenceNumber = MatchingReferenceNumber.FromIpaffs("CHEDP.GB.2024.1036543V");

        referenceNumber.LicenceType.Should().Be("CHD");
        referenceNumber.CountryCode.Should().Be("GB");
        referenceNumber.Identifier.Should().Be(1036543);
        referenceNumber.Year.Should().Be(2024);
        referenceNumber.SplitIdentifier.Should().Be('V');
        referenceNumber.AsCdsDocumentReference().Should().Be("GBCHD2024.1036543V");
        referenceNumber.AsYearIdentifier().Should().Be("2024.1036543");
    }

    [Fact]
    public void ReferenceNumber_FromCds_NoSplitIndicator()
    {
        var referenceNumber = MatchingReferenceNumber.FromCds("GBCHD2024.1036543");

        //referenceNumber.ChedType.Should().Be("CHEDP");
        referenceNumber.LicenceType.Should().Be("CHD");
        referenceNumber.CountryCode.Should().Be("GB");
        referenceNumber.Identifier.Should().Be(1036543);
        referenceNumber.Year.Should().Be(2024);
        referenceNumber.SplitIdentifier.Should().BeNull();
        referenceNumber.AsCdsDocumentReference().Should().Be("GBCHD2024.1036543");
        referenceNumber.AsYearIdentifier().Should().Be("2024.1036543");
    }

    [Fact]
    public void ReferenceNumber_FromCdss_HasSplitIndicator()
    {
        var referenceNumber = MatchingReferenceNumber.FromCds("GBCHD2024.1036543V");

        referenceNumber.LicenceType.Should().Be("CHD");
        referenceNumber.CountryCode.Should().Be("GB");
        referenceNumber.Identifier.Should().Be(1036543);
        referenceNumber.Year.Should().Be(2024);
        referenceNumber.SplitIdentifier.Should().Be('V');
        referenceNumber.AsCdsDocumentReference().Should().Be("GBCHD2024.1036543V");
        referenceNumber.AsYearIdentifier().Should().Be("2024.1036543");
    }
}