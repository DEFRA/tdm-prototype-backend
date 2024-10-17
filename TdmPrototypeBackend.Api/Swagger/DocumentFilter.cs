using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using TdmPrototypeBackend.Types.Extensions;

namespace TdmPrototypeBackend.Api.Swagger;

public class DocumentFilter : IDocumentFilter, ISchemaFilter
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
    
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Exclude BsonIgnore fields
        if (schema?.Properties == null || context.Type == null)
            return;

        var excludedProperties = context.Type.GetProperties()
            .Where(t =>
                t.GetCustomAttribute(typeof(BsonIgnoreAttribute)) != null || t.GetCustomAttribute(typeof(ApiIgnoreAttribute)) != null);

        foreach (var excludedProperty in excludedProperties)
        {
            var jsonAttr = excludedProperty.GetCustomAttribute<JsonPropertyNameAttribute>();
            var name = jsonAttr != null ? jsonAttr.Name : excludedProperty.Name;
            if (schema.Properties.ContainsKey(name))
                schema.Properties.Remove(name);
        }


        //apply description
        foreach (var excludedProperty in context.Type.GetProperties())
        {
            var descAttr = excludedProperty.GetCustomAttribute<DescriptionAttribute>();
            if (descAttr is not null)
            {
                var jsonAttr = excludedProperty.GetCustomAttribute<JsonPropertyNameAttribute>();
                var name = jsonAttr != null ? jsonAttr.Name : excludedProperty.Name;
                if (schema.Properties.TryGetValue(name, out var property))
                {
                    property.Description = descAttr.Description;
                }
            }
        }

        if(context.Type.IsEnum)
        {
            var enumOpenApiStrings = new List<IOpenApiAny>();
            foreach (var enumValue in Enum.GetValues(context.Type))
            {
                enumOpenApiStrings.Add(new OpenApiString(enumValue.ToString()));
            }

            schema.Enum = enumOpenApiStrings;
        }
    }
}