
@secure()
param sqlAdminPassword string

var suffix = uniqueString(resourceGroup().id)
resource sqlServer 'Microsoft.Sql/servers@2021-05-01-preview'={
  location: resourceGroup().location    
  name: 'cad-mining-sql'  
  properties: {
      administratorLogin: 'sky'
      administratorLoginPassword: sqlAdminPassword
      version: '12.0'            
      minimalTlsVersion: '1.2'
       publicNetworkAccess: 'Enabled'
    }  
}

resource sqlDatabase 'Microsoft.Sql/servers/databases@2021-05-01-preview'={
  name: 'cad-mining-db'
  location: resourceGroup().location
  parent: sqlServer
  sku: {
    capacity: 5    
    name: 'Basic'    
    tier: 'Basic'
  }
  properties: {
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    maxSizeBytes: 2147483648                    
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    zoneRedundant: false
    readScale: 'Disabled'    
    requestedBackupStorageRedundancy: 'Local'    
    isLedgerOn: false    
    
  }
}
