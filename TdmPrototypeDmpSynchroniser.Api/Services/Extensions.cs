using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

static class Extensions
{
    internal static void WriteRequestToConsole(this HttpResponseMessage response)
    {
        var request = response.RequestMessage;
        Console.Write($"{request?.Method} ");
        Console.Write($"{request?.RequestUri} ");
        Console.WriteLine($"HTTP/{request?.Version}");        
    }
    
    internal static void AssertIsNotNull([NotNull] object? nullableReference) {
        if(nullableReference == null) {
            throw new ArgumentNullException();
        }
    }

    internal static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}