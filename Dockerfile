﻿#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Add curl to template.
# CDP PLATFORM HEALTHCHECK REQUIREMENT
RUN apt update && \
    apt install curl -y


FROM mcr.microsoft.com/dotnet/sdk:8.0-bookworm-slim AS build
WORKDIR /src

COPY . .
WORKDIR "/src/TdmPrototypeBackend.Api"

FROM build AS publish
RUN dotnet publish "TdmPrototypeBackend.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# unit test and code coverage
# use the label to identity this layer later
LABEL test=true
# below is an example we can use in the future if we choose to use XPlat Code Coverage
#RUN dotnet test -c Release --collect:"XPlat Code Coverage" --results-directory /app/testresults "../Defra.Cdp.TdmPrototypeBackend.UnitTests/Defra.Cdp.TdmPrototypeBackend.UnitTests.csproj"
RUN dotnet test ../TdmPrototypeBackend.Test --filter Category!=Integration

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ARG PORT=8085
ENV PORT ${PORT}
ENV ASPNETCORE_HTTP_PORTS=${PORT}
EXPOSE ${PORT}
ENTRYPOINT ["dotnet", "TdmPrototypeBackend.Api.dll"]
