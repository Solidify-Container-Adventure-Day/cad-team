param location string = resourceGroup().location
param envName string = 'cad-mining'

param appcontainerImage string
param apicontainerImage string

param appcontainerPort int
param apicontainerPort int

param registry string
param registryUsername string

@secure()
param registryPassword string

@secure()
param dbConnectionString string



module law 'law.bicep' = {
    name: 'log-analytics-workspace'
    params: {
      location: location
      name: 'law-${envName}'
    }
}

module containerAppEnvironment 'environment.bicep' = {
  name: 'container-app-environment'
  params: {
    name: envName
    location: location
    lawClientId:law.outputs.clientId
    lawClientSecret: law.outputs.clientSecret
  }
}

module containerApi 'containerapp.bicep' = {
  name: '${envName}-api'
  params: {
    name: '${envName}-api'
    location: location
    containerAppEnvironmentId: containerAppEnvironment.outputs.id
    containerImage: apicontainerImage
    containerPort: apicontainerPort
    envVars: [
        {
          name: 'ASPNETCORE_ENVIRONMENT'
          value: 'Production'
        }
        {
          name: 'ConnectionStrings__Database'
          secretref: 'db-connection-string'
        }
    ]
    useExternalIngress: true
    registry: registry
    registryUsername: registryUsername
    registryPassword: registryPassword
    dbConnectionString: dbConnectionString
  }
}

module containerApp 'containerapp.bicep' = {
  name: '${envName}-web'
  params: {
    name: '${envName}-web'
    location: location
    containerAppEnvironmentId: containerAppEnvironment.outputs.id
    containerImage: appcontainerImage
    containerPort: appcontainerPort
    envVars: [  
      {
      name: 'API_URL'
      value: 'https://${containerApi.outputs.fqdn}'
      }
     ]
    useExternalIngress: true
    registry: registry
    registryUsername: registryUsername
    registryPassword: registryPassword
    dbConnectionString: dbConnectionString
  }
}
output fqdn string = containerApi.outputs.fqdn
