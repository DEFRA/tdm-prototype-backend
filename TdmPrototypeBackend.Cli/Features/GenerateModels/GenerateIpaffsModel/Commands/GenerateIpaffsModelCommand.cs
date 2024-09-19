using CommandLine;
using MediatR;
using TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateIpaffsModel.Builders;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateIpaffsModel.Commands
{

    [Verb("generate-ipaffs-model", isDefault: false, HelpText = "Generates Csharp Ipaffs classes from Json Schema.")]
    class GenerateIpaffsModelCommand : IRequest
    {
        [Option('s', "schema", Required = true, HelpText = "The Json schema file, which to use to generate the csharp classes.")]
        public string SchemaFile { get; set; }

        [Option('o', "outputPath", Required = true, HelpText = "The path to save the generated csharp classes.")]
        public string OutputPath { get; set; }

        public class Handler : AsyncRequestHandler<GenerateIpaffsModelCommand>
        {
            protected override async Task Handle(GenerateIpaffsModelCommand request, CancellationToken cancellationToken)
            {
                var builder = new IpaffsDescriptorBuilder(new List<ISchemaVisitor>() { new DescriptorBuilderSchemaVisitor() });
                // var model = builder.Build(File.ReadAllText("jsonschema.txt"));
                var model = builder.Build(await File.ReadAllTextAsync(request.SchemaFile, cancellationToken));

                await CSharpFileBuilder.Build(model, request.OutputPath);
            }
        }
    }
}
