FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["BookYourMealAPI/BookYourMealAPI.csproj", "BookYourMealAPI/"]
RUN dotnet restore "BookYourMealAPI/BookYourMealAPI.csproj"
COPY . .
WORKDIR "/src/BookYourMealAPI"
RUN dotnet build "BookYourMealAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookYourMealAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookYourMealAPI.dll"]