using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeDmpSynchroniser.Api.SensitiveData;

namespace TdmPrototypeDmpSynchroniser.Api.SensitiveData;

public class SensitiveDataTypeInfoResolver(ISensitiveDataOptions sensitiveDataOptions) : DefaultJsonTypeInfoResolver
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
                        if (property.PropertyType == typeof(string))
                        {
                            property.CustomConverter =
                                new Api.SensitiveData.SensitiveDataRedactedConverter(sensitiveDataOptions);
                        }
                        else if (property.PropertyType == typeof(string[]))
                        {
                            property.CustomConverter =
                                new Api.SensitiveData.StringArraySensitiveDataRedactedConverter(sensitiveDataOptions);
                        }
                    }
                }
            }
        }
        return typeInfo;
    }
}