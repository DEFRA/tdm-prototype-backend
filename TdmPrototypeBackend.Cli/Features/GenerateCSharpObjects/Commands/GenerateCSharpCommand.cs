using CommandLine;
using MediatR;
using RazorLight;
using System.Security.Claims;
using TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.Builders;

namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.Commands
{

    [Verb("generate-csharp-from-json-schema", isDefault: true, HelpText = "Generates Csharp classes from Json Schema.")]
    class GenerateCSharpCommand : IRequest
    {
        [Option('s', "schema", Required = true, HelpText = "The Json schema file, which to use to generate the csharp classes.")]
        public string SchemaFile { get; set; }

        [Option('o', "outputPath", Required = true, HelpText = "The path to save the generated csharp classes.")]
        public string OutputPath { get; set; }

        public class Handler : AsyncRequestHandler<GenerateCSharpCommand>
        {
            protected override async Task Handle(GenerateCSharpCommand request, CancellationToken cancellationToken)
            {
                var builder = new CSharpDescriptorBuilder(new List<ISchemaVisitor>() { new DescriptorBuilderSchemaVisitor() });
               // var model = builder.Build(File.ReadAllText("jsonschema.txt"));
                var model = builder.Build(await File.ReadAllTextAsync(request.SchemaFile, cancellationToken));

                var engine = new RazorLightEngineBuilder()
                    // required to have a default RazorLightProject type,
                    // but not required to create a template from string.
                    .UseEmbeddedResourcesProject(typeof(Program).Assembly, "TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.Templates")
                    .UseMemoryCachingProvider()
                    .Build();

                foreach (var @class in model.Classes.OrderBy(x => x.Name))
                {
                    string contents = await engine.CompileRenderAsync("ClassTemplate", @class);
                    //await File.WriteAllTextAsync($"../../../Model/{@class.GetClassName()}.cs", contents, cancellationToken);
                    await File.WriteAllTextAsync(Path.Combine(request.OutputPath, $"{@class.GetClassName()}.g.cs"), contents, cancellationToken);
                    Console.WriteLine($"Created file: {@class.GetClassName()}.cs");
                }

                foreach (var @enum in model.Enums.OrderBy(x => x.Name))
                {
                    string contents = await engine.CompileRenderAsync("EnumTemplate", @enum);
                    await File.WriteAllTextAsync(Path.Combine(request.OutputPath, $"{@enum.GetEnumName()}.g.cs"), contents, cancellationToken);
                   // File.WriteAllText($"../../../Model/{@enum.GetEnumName()}.cs", contents);
                    Console.WriteLine($"Created file: {@enum.GetEnumName()}.cs");
                }
            }
        }
    }
}
