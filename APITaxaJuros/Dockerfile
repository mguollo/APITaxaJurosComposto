FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY APITaxaJuros.csproj /build/

RUN dotnet restore ./build/APITaxaJuros.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./APITaxaJuros.csproj -c ${BUILDCONFIG} -o out /p:Version=${VERSION}

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "APITaxaJuros.dll"]