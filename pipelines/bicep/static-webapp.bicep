param appName string

@minLength(3)
@maxLength(3)
param environment string

param tags object

param location string

var identity = {
  type: 'SystemAssigned'
}

var sku = 'Standard'

resource staticWebApp 'Microsoft.Web/staticSites@2022-03-01' = {
  name: '${appName}-${environment}'
  location: location
  sku: {
    name: sku
    size: sku
  }
  identity: identity
  tags: tags
  properties: {
    
  }
}

output webApp object = {
  name: staticWebApp.name
  id: staticWebApp.id
  defaultHostName: staticWebApp.properties.defaultHostname
  principalId: staticWebApp.identity.principalId
}
