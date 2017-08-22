FROM microsoft/dotnet:2.0-runtime
COPY bin/Release/netcoreapp2.0 /app
WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "ShoppingListService.WebApi.dll"]