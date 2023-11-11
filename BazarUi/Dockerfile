#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

ENV CATALOGURL=http://192.168.1.6:5000
ENV ORDERURL=http://192.168.1.6:5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BazarUi/BazarUi.csproj", "BazarUi/"]
RUN dotnet restore "BazarUi/BazarUi.csproj"
COPY . .
WORKDIR "/src/BazarUi"
RUN dotnet build "BazarUi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BazarUi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BazarUi.dll"]