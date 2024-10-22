using AutoBogus;
using FluentAssertions;
using Xunit;

namespace Tdm.Types.Alvs.Mapping.Tests;

public class ServiceHeaderMapperTests
{
    [Fact]
    public void SimpleMapperTest()
    {
        var faker = AutoFaker.Create();
        var sourceValue = faker.Generate<Tdm.Types.Alvs.ServiceHeader>();

        var mappedValue = ServiceHeaderMapper.Map(sourceValue);


        mappedValue.ServiceCallTimestamp.Should().Be(sourceValue.ServiceCallTimestamp);
        mappedValue.CorrelationId.Should().Be(sourceValue.CorrelationId);
        mappedValue.DestinationSystem.Should().Be(sourceValue.DestinationSystem);
        mappedValue.SourceSystem.Should().Be(sourceValue.SourceSystem);
    }
}