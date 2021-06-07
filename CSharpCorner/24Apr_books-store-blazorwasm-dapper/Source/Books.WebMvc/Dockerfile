#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Source/Books.WebMvc/Books.WebMvc.csproj", "Source/Books.WebMvc/"]
COPY ["Source/Books.Data/Books.Data.csproj", "Source/Books.Data/"]
RUN dotnet restore "Source/Books.WebMvc/Books.WebMvc.csproj"
COPY . .
WORKDIR "/src/Source/Books.WebMvc"
RUN dotnet build "Books.WebMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Books.WebMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Books.WebMvc.dll"]