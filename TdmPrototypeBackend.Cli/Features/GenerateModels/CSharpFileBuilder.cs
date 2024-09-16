using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorLight;
using TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels
{
    class CSharpFileBuilder
    {
        public static async Task Build(CSharpDescriptor descriptor, string outputPath, CancellationToken cancellationToken = default)
        {
            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program).Assembly, "TdmPrototypeBackend.Cli.Features.GenerateModels.Templates")
                .UseMemoryCachingProvider()
                .Build();

            foreach (var @class in descriptor.Classes.OrderBy(x => x.Name))
            {
                var contents = await engine.CompileRenderAsync("ClassTemplate", @class);
                await File.WriteAllTextAsync(Path.Combine(outputPath, $"{@class.GetClassName()}.g.cs"), contents, cancellationToken);
                Console.WriteLine($"Created file: {@class.GetClassName()}.cs");
            }
            
            foreach (var @enum in descriptor.Enums.OrderBy(x => x.Name))
            {
                var contents = await engine.CompileRenderAsync("EnumTemplate", @enum);
                await File.WriteAllTextAsync(Path.Combine(outputPath, $"{@enum.GetEnumName()}.g.cs"), contents, cancellationToken);
                // File.WriteAllText($"../../../Model/{@enum.GetEnumName()}.cs", contents);
                Console.WriteLine($"Created file: {@enum.GetEnumName()}.cs");
            }
        }
    }
}
