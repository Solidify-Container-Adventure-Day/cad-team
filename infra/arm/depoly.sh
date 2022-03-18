# the resource group provied
RESOURCE_GROUP="<team resource group>"
# the location .i.e westeurope, northeurope, etc
LOCATION="<location>"
# Name of the containerapp service environment"
CONTAINERAPPS_ENVIRONMENT="<team-env-name>"

# login to azure
az login --use-device-code --tenant <tenant-id>

# Get user and password for ACR
acrUser=$(az acr credential show -n <team-acr> --query username -o tsv)
acrPassword=$(az acr credential show -n <team-acr> --query "passwords[0].value" -o tsv)

#setup connectionstring to db
dbConnectionString="Server=tcp:cad-mining-sql.database.windows.net,1433;Initial Catalog=cad-mining-db;Persist Security Info=False;User ID=sky;Password=SqlDb12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

# az commant to run
az deployment group create -n container-day-app \
  -g $RESOURCE_GROUP \
  -f ./main.bicep \
  -p appcontainerImage=<acr-url/frontend-image-name:image-version> \
     appcontainerPort=3000 \
     apicontainerImage=<acr-url/backend-image-name:image-version> \
     apicontainerPort=3001 \
     registry=<acr-url> \
     registryUsername=$acrUser \
     registryPassword=$acrPassword \
     dbConnectionString="$dbConnectionString"
