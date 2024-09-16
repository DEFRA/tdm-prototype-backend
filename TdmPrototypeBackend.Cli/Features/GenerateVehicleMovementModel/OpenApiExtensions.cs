using Json.Schema;
using Microsoft.OpenApi.Models;

namespace TdmPrototypeBackend.Cli.Features.GenerateVehicleMovementModel;

public static class OpenApiExtensions
{
    public static bool IsArray(this OpenApiSchema schema)
    {
        return schema.Type == "array";
    }

    public static bool IsObject(this OpenApiSchema schema)
    {
        return schema.Type == "object" || schema.Properties.Any();
    }

    public static string GetArrayType(this OpenApiSchema schema)
    {
        return schema.Items.Type;
    }

    public static string ToCSharpType(this string openApiType)
    {
        return openApiType switch
        {
            "Boolean" => "bool",
            "boolean" => "bool",
            "string" => "string",
            "integer" => "int",
            "array" => "array",
            "object" => "objectTDB",
            "" => "",
            null => null,
            _ => throw new ArgumentOutOfRangeException(nameof(openApiType), openApiType, null)
        };
    }
}