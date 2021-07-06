#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./*.sln  ./

# Copy the main source project files
COPY ./src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

RUN dotnet restore

# copy everything else and build
COPY . ./

FROM build AS publish
RUN dotnet publish ./src/Courses.WebApi/Courses.WebApi.csproj -c Release

FROM base AS final
WORKDIR /app
COPY --from=publish /app/src/Courses.WebApi/bin/Release/net6.0/publish .
ENTRYPOINT ["dotnet", "Courses.WebApi.dll"]
