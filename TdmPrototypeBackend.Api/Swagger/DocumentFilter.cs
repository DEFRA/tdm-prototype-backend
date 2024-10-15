using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TdmPrototypeBackend.Api.Swagger;

public class DocumentFilter : IDocumentFilter
{
    public DocumentFilter()
    {
        Thread.Sleep(20);
    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        if (context.DocumentName.StartsWith("public"))
        {
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
                pathDescription: "Notification Operations",
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