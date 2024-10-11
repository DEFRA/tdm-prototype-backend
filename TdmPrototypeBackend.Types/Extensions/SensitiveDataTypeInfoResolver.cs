using Humanizer;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace TdmPrototypeBackend.Types.Extensions;

public class SensitiveDataTypeInfoResolver(SensitiveDataOptions sensitiveDataOptions) : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo typeInfo = base.GetTypeInfo(type, options);
       
        if (typeInfo.Kind == JsonTypeInfoKind.Object)
        {
            foreach (var property in typeInfo.Properties)
            {
                if (!sensitiveDataOptions.Include)
                {
                    if (property.AttributeProvider.GetCustomAttributes(typeof(SensitiveDataAttribute), false).Any())
                    {
                        property.CustomConverter = new SensitiveDataRedactedConverter(sensitiveDataOptions);
                    }
                }
            }
        }
        return typeInfo;
    }
}