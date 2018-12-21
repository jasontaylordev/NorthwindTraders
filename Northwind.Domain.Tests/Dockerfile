FROM microsoft/dotnet:2.2-sdk
WORKDIR /

# Restore dotnet before build to allow for caching
COPY Northwind.Common/Northwind.Common.csproj /src/Northwind.Common/
COPY Northwind.Domain/Northwind.Domain.csproj /src/Northwind.Domain/
COPY Northwind.Domain.Tests/Northwind.Domain.Tests.csproj /src/Northwind.Domain.Tests/

RUN dotnet restore /src/Northwind.Domain.Tests/Northwind.Domain.Tests.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/Northwind.Domain.Tests/Northwind.Domain.Tests.csproj --no-restore -c Release -o /app

WORKDIR /src/Northwind.Domain.Tests
ENTRYPOINT ["dotnet", "test"]