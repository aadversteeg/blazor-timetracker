targetScope = 'resourceGroup'

param appName string
param appShortName string

@minLength(3)
@maxLength(3)
param environment string = 'tst'

param customTags object = {}

param location string = 'westeurope'

module appService 'static-webapp.bicep' = {
  name: 'StaticWebAppDeploy'
  params: {
    appName: appShortName
    environment: environment
    tags: customTags
    location: location
  }
}

