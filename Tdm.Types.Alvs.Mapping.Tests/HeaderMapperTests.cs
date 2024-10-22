using AutoBogus;
using FluentAssertions;
using System.Text.Json.Serialization;
using Xunit;

namespace Tdm.Types.Alvs.Mapping.Tests
{
    public class HeaderMapperTests
    {
        [Fact]
        public void SimpleMapperTest()
        {
            var faker = AutoFaker.Create();
            var sourceHeader = faker.Generate<Tdm.Types.Alvs.Header>();

            var mappedHeader = HeaderMapper.Map(sourceHeader);

            mappedHeader.EntryReference.Should().Be(sourceHeader.EntryReference);
            mappedHeader.EntryVersionNumber.Should().Be(sourceHeader.EntryVersionNumber);
            mappedHeader.PreviousVersionNumber.Should().Be(sourceHeader.PreviousVersionNumber);
            mappedHeader.DeclarationUCR.Should().Be(sourceHeader.DeclarationUCR);
            mappedHeader.DeclarationPartNumber.Should().Be(sourceHeader.DeclarationPartNumber);
            mappedHeader.DeclarationType.Should().Be(sourceHeader.DeclarationType);
            mappedHeader.ArrivalDateTime.Should().Be(sourceHeader.ArrivalDateTime);
            mappedHeader.SubmitterTurn.Should().Be(sourceHeader.SubmitterTurn);
            mappedHeader.DeclarantId.Should().Be(sourceHeader.DeclarantId);

            mappedHeader.DeclarantName.Should().Be(sourceHeader.DeclarantName);
            mappedHeader.DispatchCountryCode.Should().Be(sourceHeader.DispatchCountryCode);
            mappedHeader.GoodsLocationCode.Should().Be(sourceHeader.GoodsLocationCode);
            mappedHeader.MasterUcr.Should().Be(sourceHeader.MasterUcr);
        }

    }
}
