FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 5101
ENV ASPNETCORE_URLS=http://*:5101
WORKDIR /app
ENV ConnectionStrings:RestauranteConnection=server=mysql-svc;database=restaurantedb;user=dbuser;password=db1234
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "RestauranteService.dll" ]