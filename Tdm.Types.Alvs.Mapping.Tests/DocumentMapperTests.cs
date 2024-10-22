﻿using AutoBogus;
using FluentAssertions;
using Xunit;

namespace Tdm.Types.Alvs.Mapping.Tests;

public class DocumentMapperTests
{
    [Fact]
    public void SimpleMapperTest()
    {
        var faker = AutoFaker.Create();
        var sourceValue = faker.Generate<Tdm.Types.Alvs.Document>();

        var mappedValue = DocumentMapper.Map(sourceValue);


        mappedValue.DocumentReference.Should().Be(sourceValue.DocumentReference);
        mappedValue.DocumentCode.Should().Be(sourceValue.DocumentCode);
        mappedValue.DocumentControl.Should().Be(sourceValue.DocumentControl);
        mappedValue.DocumentQuantity.Should().Be(sourceValue.DocumentQuantity);
        mappedValue.DocumentStatus.Should().Be(sourceValue.DocumentStatus);
    }
}