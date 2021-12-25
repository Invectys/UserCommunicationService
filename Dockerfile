FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
RUN dotnet publish -c Release -o published
COPY published .

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
COPY --from=build-env . .
ENTRYPOINT ["dotnet", "UserCommunicationService.dll"]
