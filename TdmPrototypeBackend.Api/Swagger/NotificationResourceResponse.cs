using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using System.Text.Json;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Types.VehicleMovement;

namespace TdmPrototypeBackend.Api.Swagger
{
    public class NotificationResourceResponse : ResourceResponse<Notification>
    {

    }

    public class MovementResourceResponse : ResourceResponse<Movement>
    {

    }

    public class GmrResourceResponse : ResourceResponse<Gmr>
    {

    }
    public class ResourceResponse<T>
    {
        public ResourceData<T> Data { get; set; }
    }

    public class ResourceData<T>
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public T Attributes { get; set; }
    }

    public static class SwaggerExtensions
    {
        public static void AddPath(this OpenApiDocument swaggerDoc, string path, string pathDescription,
            string operationDescription, string referenceId, string tag)
        {
            swaggerDoc.Paths.Add(path, new OpenApiPathItem()
            {
                Description = pathDescription,
                Operations = new Dictionary<OperationType, OpenApiOperation>()
                {
                    {
                        OperationType.Get, new OpenApiOperation()
                        {
                            Description = operationDescription,
                            Responses = new OpenApiResponses()
                            {
                                { "200", new OpenApiResponse()
                                {
                                    Description = "success",
                                    Content = new Dictionary<string, OpenApiMediaType>()
                                    {
                                    {
                                        "application/json", new OpenApiMediaType()
                                        {
                                            Schema = new OpenApiSchema()
                                            {
                                                Reference = new OpenApiReference()
                                                {
                                                    Id = referenceId,
                                                    Type =  ReferenceType.Schema,

                                                }
                                            }
                                        }
                                    }}
                                }}
                            },
                            Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = tag}},
                        }
                    }
                }
            });
        }
    }

    
    public class DocumentFilter : IDocumentFilter
    {
        public DocumentFilter()
        {
            Thread.Sleep(20);
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(swaggerDoc,
                new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
            
            
            context.SchemaGenerator.GenerateSchema(typeof(NotificationResourceResponse), context.SchemaRepository);
            context.SchemaGenerator.GenerateSchema(typeof(GmrResourceResponse), context.SchemaRepository);
            context.SchemaGenerator.GenerateSchema(typeof(MovementResourceResponse), context.SchemaRepository);


            foreach (var apiSchema in swaggerDoc.Components.Schemas)
            {
                foreach (var valueProperty in apiSchema.Value.Properties)
                {
                    if (valueProperty.Key.StartsWith("_"))
                    {
                        apiSchema.Value.Properties.Remove(valueProperty);
                    }
                }

                
            }

            //swaggerDoc.Components.Schemas

            swaggerDoc.AddPath(
                path: "/notifications",
                pathDescription:"Notification Operations",
                operationDescription: "Get Notifications",
                referenceId: "NotificationResourceResponse",
                tag: "Notifications");

            swaggerDoc.AddPath(
                path: "/movements",
                pathDescription: "Movement Operations",
                operationDescription: "Get Movements",
                referenceId: "NMovementResourceResponse",
                tag: "Movements");

            swaggerDoc.AddPath(
                path: "/grms",
                pathDescription: "GRM Operations",
                operationDescription: "Get Gmrs",
                referenceId: "GmrResourceResponse",
                tag: "Gmrs");

        }
    }
}
