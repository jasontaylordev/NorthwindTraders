FROM microsoft/dotnet:2.2-sdk
WORKDIR /

# Restore dotnet before build to allow for caching
COPY Northwind.Application/Northwind.Application.csproj /src/Northwind.Application/
COPY Northwind.Application.Tests/Northwind.Application.Tests.csproj /src/Northwind.Application.Tests/
COPY Northwind.Common/Northwind.Common.csproj /src/Northwind.Common/
COPY Northwind.Domain/Northwind.Domain.csproj /src/Northwind.Domain/
COPY Northwind.Persistence/Northwind.Persistence.csproj /src/Northwind.Persistence/

RUN dotnet restore /src/Northwind.Application.Tests/Northwind.Application.Tests.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/Northwind.Application.Tests/Northwind.Application.Tests.csproj --no-restore -c Release -o /app

WORKDIR /src/Northwind.Application.Tests
ENTRYPOINT ["dotnet", "test"]   