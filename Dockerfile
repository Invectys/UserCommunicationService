FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
COPY . .
RUN dotnet publish -c Release -o published

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
COPY --from=build-env published .
ENTRYPOINT ["dotnet", "UserCommunicationService.dll"]
