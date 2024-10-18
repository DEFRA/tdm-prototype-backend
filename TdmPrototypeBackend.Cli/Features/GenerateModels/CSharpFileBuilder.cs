using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorLight;
using System.Security.Claims;
using TdmPrototypeBackend.Cli.Features.GenerateModels.ClassMaps;
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
                ApplyClassMapOverrides(@class);

                var contents = await engine.CompileRenderAsync("ClassTemplate", @class);
                await File.WriteAllTextAsync(Path.Combine(outputPath, $"{@class.GetClassName()}.g.cs"), contents, cancellationToken);
                Console.WriteLine($"Created file: {@class.GetClassName()}.cs");
            }
            
            foreach (var @enum in descriptor.Enums.OrderBy(x => x.Name))
            {
                ApplyEnumMapOverrides(@enum);

                var contents = await engine.CompileRenderAsync("EnumTemplate", @enum);
                await File.WriteAllTextAsync(Path.Combine(outputPath, $"{@enum.GetEnumName()}.g.cs"), contents, cancellationToken);
                // File.WriteAllText($"../../../Model/{@enum.GetEnumName()}.cs", contents);
                Console.WriteLine($"Created file: {@enum.GetEnumName()}.cs");
            }
        }

        private static void ApplyClassMapOverrides(ClassDescriptor @class)
        {
            var classMap = GeneratorClassMap.LookupClassMap(@class.Name);

            if (classMap is not null)
            {
                @class.Name = classMap.ClassName;
                foreach (var propertyMap in classMap.Properties)
                {
                    var propertyDescriptor = @class.Properties.FirstOrDefault(x => x.Name.Equals(propertyMap.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (propertyDescriptor is not null)
                    {
                        if (propertyMap.TypeOverwritten)
                        {
                            propertyDescriptor.OverrideType(propertyMap.Type);
                        }

                        if (propertyMap.NameOverwritten)
                        {
                            propertyDescriptor.Name = propertyMap.OverriddenName;
                        }

                        if (propertyMap.AttributesOverwritten)
                        {
                            if (propertyMap.NoAttributes)
                            {
                                propertyDescriptor.Attributes.Clear();
                            }
                            else
                            {
                                propertyDescriptor.Attributes.AddRange(propertyMap.Attributes);
                            }
                                
                        }

                        if (propertyMap.ExcludedFromApi)
                        {
                            propertyDescriptor.Attributes.RemoveAll(x => x.Equals("[Attr]"));
                        }
                    }
                }
            }
        }

        private static void ApplyEnumMapOverrides(EnumDescriptor @enum)
        {
            var classMap = GeneratorEnumMap.LookupEnumMap(@enum.Name);

            if (classMap is not null)
            {
               
                @enum.Values.AddRange(classMap.EnumValues);
            }
        }
    }
}
