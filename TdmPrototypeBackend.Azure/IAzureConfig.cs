﻿namespace TdmPrototypeBackend.Azure;

public interface IAzureConfig
{
    public string? AzureClientId { get; }
    public string? AzureTenantId { get; }
    public string? AzureClientSecret { get; }
}