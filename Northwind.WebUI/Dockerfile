FROM microsoft/dotnet:2.2-aspnetcore-runtime AS Base
WORKDIR /
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

ENV NODE_VERSION 8.12.0
#ENV YARN_VERSION 1.9.4
ENV NODE_DOWNLOAD_SHA 3df19b748ee2b6dfe3a03448ebc6186a3a86aeab557018d77a0f7f3314594ef6
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz

RUN wget "$NODE_DOWNLOAD_URL" -O nodejs.tar.gz \
	&& echo "$NODE_DOWNLOAD_SHA  nodejs.tar.gz" | sha256sum -c - \
	&& tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
	&& rm nodejs.tar.gz \
#	&& npm i -g yarn@$YARN_VERSION \
	&& ln -s /usr/local/bin/node /usr/local/bin/nodejs

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

COPY Northwind.Application/Northwind.Application.csproj /src/Northwind.Application/
COPY Northwind.Common/Northwind.Common.csproj /src/Northwind.Common/
COPY Northwind.Domain/Northwind.Domain.csproj /src/Northwind.Domain/
COPY Northwind.Infrastructure/Northwind.Infrastructure.csproj /src/Northwind.Infrastructure/
COPY Northwind.Persistence/Northwind.Persistence.csproj /src/Northwind.Persistence/
COPY Northwind.WebUI/Northwind.WebUI.csproj /src/Northwind.WebUI/

RUN dotnet restore /src/Northwind.WebUI/Northwind.WebUI.csproj

COPY Northwind.WebUI/ClientApp/package.json /src/Northwind.WebUI/ClientApp/
COPY Northwind.WebUI/ClientApp/package-lock.json /src/Northwind.WebUI/ClientApp/

WORKDIR /src/Northwind.WebUI/ClientApp/

RUN npm install

WORKDIR /
COPY . /src

RUN dotnet build /src/Northwind.WebUI/Northwind.WebUI.csproj --no-restore -c Release
RUN dotnet publish /src/Northwind.WebUI/Northwind.WebUI.csproj --no-restore -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=build /app .
CMD ["dotnet", "Northwind.WebUI.dll"]