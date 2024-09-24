using System.Xml;
using System.Xml.Schema;
using CommandLine;
using Humanizer;
using MediatR;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;
using TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateVehicleMovementModel;
using TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateVehicleMovementModel.Commands;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateAlvsModel.Commands
{
    [Verb("generate-alvs-model", isDefault: false, HelpText = "Generates Csharp ALVS classes from XSD Schema.")]
    class GenerateAlvsModelCommand : IRequest
    {
        public const string Namespace = "TdmPrototypeBackend.Types.Alvs";
        public const string ClassNamePrefix = "";

        public string OutputPath { get; set; } = "D:\\repos\\esynergy\\tdm-prototype-backend\\TdmPrototypeBackend.Types\\Alvs\\";
        public class Handler : AsyncRequestHandler<GenerateAlvsModelCommand>
        {
           
            protected override async Task Handle(GenerateAlvsModelCommand request, CancellationToken cancellationToken)
            {
                XmlTextReader reader = new XmlTextReader("D:\\repos\\esynergy\\tdm-prototype-backend\\TdmPrototypeBackend.Cli\\Features\\GenerateModels\\GenerateAlvsModel\\sendALVSClearanceRequest.xsd");
                XmlSchema schema = XmlSchema.Read(reader, ValidationCallback);

                var csharpDescriptor = new CSharpDescriptor();

                foreach (var schemaItem in schema.Items)
                {
                    if (schemaItem is XmlSchemaComplexType complexType)
                    {
                        BuildClass(csharpDescriptor, complexType);
                    }
                }

                await CSharpFileBuilder.Build(csharpDescriptor, request.OutputPath, cancellationToken);
            }

            private void BuildClass(CSharpDescriptor cSharpDescriptor, XmlSchemaComplexType complexType)
            {
                var name = complexType.Name;

                if (string.IsNullOrEmpty(name))
                {
                    name = ((XmlSchemaElement)complexType.Parent).Name;
                }

                Console.WriteLine($"Class Name: {name}");
                var classDescriptor = new ClassDescriptor(name, Namespace, ClassNamePrefix);

                classDescriptor.Description = complexType.GetDescription();
                cSharpDescriptor.AddClassDescriptor(classDescriptor);

                if (complexType.Particle is XmlSchemaSequence sequence)
                {
                    foreach (var sequenceItem in sequence.Items)
                    {
                        if (sequenceItem is XmlSchemaElement schemaSequence)
                        {
                            if (schemaSequence.SchemaType is XmlSchemaComplexType ct)
                            {
                                BuildClass(cSharpDescriptor, ct);
                            }
                        }

                        var schemaElement = sequenceItem as XmlSchemaElement;
                        Console.WriteLine($"Property Name: {schemaElement.Name} - Type: {schemaElement.GetSchemaType()}");
                        var propertyName = System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(schemaElement.Name);
                        var propertyDescriptor = new PropertyDescriptor(
                            name: propertyName,
                            type: schemaElement.GetSchemaType(),
                            description: "",
                            isReferenceType: false,
                            isArray: schemaElement.MaxOccursString == "unbounded",
                            classNamePrefix: ClassNamePrefix);
                        classDescriptor.Properties.Add(propertyDescriptor);
                    }


                }
            }

            static void ValidationCallback(object sender, ValidationEventArgs args)
            {
                if (args.Severity == XmlSeverityType.Warning)
                    Console.Write("WARNING: ");
                else if (args.Severity == XmlSeverityType.Error)
                    Console.Write("ERROR: ");

                Console.WriteLine(args.Message);
            }
        }
    }
}
