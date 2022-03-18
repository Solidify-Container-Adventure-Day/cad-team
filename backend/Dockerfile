
# Build application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out --no-restore
ENV ConnectionStrings__Database="<replace with your connectionstring>"
# Sample connectionstring 
# ENV ConnectionStrings__Database="Server=sql1,1433;Initial Catalog=cad-mining-db;Persist Security Info=False;User ID=sa;Password=MyStrong@Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
ENV ASPNETCORE_URLS=http://0.0.0.0:3001/
WORKDIR /app/out
EXPOSE 3001
ENTRYPOINT ["dotnet", "Cad.MiningApp.Api.dll" ]
