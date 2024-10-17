﻿using Microsoft.OpenApi.Models;

namespace TdmPrototypeBackend.Api.Swagger;

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