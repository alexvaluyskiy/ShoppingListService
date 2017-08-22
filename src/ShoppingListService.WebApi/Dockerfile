FROM microsoft/aspnetcore:2.0.0-jessie
COPY publish /app
WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "ShoppingListService.WebApi.dll"]