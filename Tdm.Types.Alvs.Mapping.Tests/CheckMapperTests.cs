using AutoBogus;
using FluentAssertions;
using Xunit;

namespace Tdm.Types.Alvs.Mapping.Tests;

public class CheckMapperTests
{
    [Fact]
    public void SimpleMapperTest()
    {
        var faker = AutoFaker.Create();
        var sourceValue = faker.Generate<Tdm.Types.Alvs.Check>();

        var mappedValue = CheckMapper.Map(sourceValue);


        mappedValue.CheckCode.Should().Be(sourceValue.CheckCode);
        mappedValue.DepartmentCode.Should().Be(sourceValue.DepartmentCode);
    }
}