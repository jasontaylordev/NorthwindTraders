FROM microsoft/dotnet:2.2-aspnetcore-runtime AS Base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

# Install node and npm
ENV NODE_VERSION 8.12.0
ENV NODE_DOWNLOAD_SHA 3df19b748ee2b6dfe3a03448ebc6186a3a86aeab557018d77a0f7f3314594ef6
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz

RUN wget "$NODE_DOWNLOAD_URL" -O nodejs.tar.gz \
	&& echo "$NODE_DOWNLOAD_SHA  nodejs.tar.gz" | sha256sum -c - \
	&& tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
	&& rm nodejs.tar.gz \
	&& ln -s /usr/local/bin/node /usr/local/bin/nodejs

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

# Install npm packages first, this is slow so we want to minimise the number of un-cached runs
WORKDIR /src/Northwind.WebUI/ClientApp/
COPY Northwind.WebUI/ClientApp/package.json .
COPY Northwind.WebUI/ClientApp/package-lock.json .

RUN npm install

# Restore dotnet before build to allow for caching
WORKDIR /
COPY Northwind.Application/Northwind.Application.csproj /src/Northwind.Application/
COPY Northwind.Common/Northwind.Common.csproj /src/Northwind.Common/
COPY Northwind.Domain/Northwind.Domain.csproj /src/Northwind.Domain/
COPY Northwind.Infrastructure/Northwind.Infrastructure.csproj /src/Northwind.Infrastructure/
COPY Northwind.Persistence/Northwind.Persistence.csproj /src/Northwind.Persistence/
COPY Northwind.WebUI/Northwind.WebUI.csproj /src/Northwind.WebUI/

RUN dotnet restore /src/Northwind.WebUI/Northwind.WebUI.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/Northwind.WebUI/Northwind.WebUI.csproj --no-restore -c Release
RUN dotnet publish /src/Northwind.WebUI/Northwind.WebUI.csproj --no-restore -c Release -o /app

# Copy compiled app to runtime container
FROM base AS final
COPY --from=build /app .
CMD ["dotnet", "Northwind.WebUI.dll"]