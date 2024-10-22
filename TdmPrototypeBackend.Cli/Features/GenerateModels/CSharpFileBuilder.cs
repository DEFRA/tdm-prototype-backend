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
        public static async Task Build(CSharpDescriptor descriptor, string sourceOutputPath, string internalOutputPath, string mappingOutputPath, CancellationToken cancellationToken = default)
        {
            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program).Assembly, "TdmPrototypeBackend.Cli.Features.GenerateModels.Templates")
                .UseMemoryCachingProvider()
                .Build();

            foreach (var @class in descriptor.Classes.OrderBy(x => x.Name))
            {
                ApplySourceClassMapOverrides(@class);

                //create source 

                var contents = await engine.CompileRenderAsync("ClassTemplate", @class);
                await File.WriteAllTextAsync(Path.Combine(sourceOutputPath, $"{@class.GetClassName()}.g.cs"), contents, cancellationToken);
                Console.WriteLine($"Created file: {@class.GetClassName()}.cs");

                //create internal 

                if (!@class.IgnoreInternalClass)
                {
                    contents = await engine.CompileRenderAsync("InternalClassTemplate", @class);
                    await File.WriteAllTextAsync(Path.Combine(internalOutputPath, $"{@class.GetClassName()}.g.cs"),
                        contents, cancellationToken);
                    Console.WriteLine($"Created file: {@class.GetClassName()}.cs");

                    contents = await engine.CompileRenderAsync("MapperTemplate", @class);
                    await File.WriteAllTextAsync(Path.Combine(mappingOutputPath, $"{@class.GetClassName()}Mapper.g.cs"), contents, cancellationToken);
                    Console.WriteLine($"Created file: {@class.GetClassName()}.cs");
                }

               
            }
            
            foreach (var @enum in descriptor.Enums.OrderBy(x => x.Name))
            {
                ApplyEnumMapOverrides(@enum);

                var contents = await engine.CompileRenderAsync("EnumTemplate", @enum);
                await File.WriteAllTextAsync(Path.Combine(sourceOutputPath, $"{@enum.GetEnumName()}.g.cs"), contents, cancellationToken);
                // File.WriteAllText($"../../../Model/{@enum.GetEnumName()}.cs", contents);
                Console.WriteLine($"Created file: {@enum.GetEnumName()}.cs");

                contents = await engine.CompileRenderAsync("EnumTemplate", @enum);
                await File.WriteAllTextAsync(Path.Combine(internalOutputPath, $"{@enum.GetEnumName()}.g.cs"), contents, cancellationToken);
                // File.WriteAllText($"../../../Model/{@enum.GetEnumName()}.cs", contents);
                Console.WriteLine($"Created file: {@enum.GetEnumName()}.cs");
            }
        }

        private static void ApplySourceClassMapOverrides(ClassDescriptor @class)
        {
            var classMap = GeneratorClassMap.LookupClassMap(@class.Name);

            if (classMap is not null)
            {
                @class.Name = classMap.SourceClassName;
                @class.IgnoreInternalClass = classMap.IgnoreInternalClass;

                foreach (var propertyMap in classMap.Properties)
                {
                    var propertyDescriptor = @class.Properties.FirstOrDefault(x => x.SourceName.Equals(propertyMap.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (propertyDescriptor is not null)
                    {
                        if (propertyMap.TypeOverwritten)
                        {
                            propertyDescriptor.OverrideType(propertyMap.Type);
                        }

                        if (propertyMap.SourceNameOverwritten)
                        {
                            propertyDescriptor.SourceName = propertyMap.OverriddenSourceName;
                        }

                        if (propertyMap.InternalNameOverwritten)
                        {
                            propertyDescriptor.InternalName = propertyMap.OverriddenInternalName;
                        }

                        if (propertyMap.AttributesOverwritten)
                        {
                            if (propertyMap.NoAttributes)
                            {
                                propertyDescriptor.SourceAttributes.Clear();
                                propertyDescriptor.InternalAttributes.Clear();
                            }
                            else
                            {
                                propertyDescriptor.SourceAttributes.AddRange(propertyMap.SourceAttributes);
                                propertyDescriptor.InternalAttributes.AddRange(propertyMap.InternalAttributes);
                            }
                                
                        }

                        if (propertyMap.ExcludedFromApi)
                        {
                            propertyDescriptor.InternalAttributes.RemoveAll(x => x.Equals("[Attr]"));
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
