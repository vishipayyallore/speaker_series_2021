SUBSCRIPTIONNAME="SwamyPKV VSPS"
RESOURCEGROUP="rg-globalaz2021-india-dev-001"
LOCATIONNAME="EastUS"
STORAGEACCT="stglobalaz2021india001"
APPINSIGHTS="appi-globalaz2021-india-001"

az login
az account set --subscription "$SUBSCRIPTIONNAME"
az account show --output table
# az account list --output table

###### Group
az group list --output table
az group create --name "$RESOURCEGROUP" --location "$LOCATIONNAME"

##### Storage Account
az storage account create --resource-group "$RESOURCEGROUP" \
  --name "$STORAGEACCT" --kind StorageV2 --location "$LOCATIONNAME"

##### Application Insights
az monitor app-insights component create --app "$APPINSIGHTS" --location "$LOCATIONNAME" --resource-group "$RESOURCEGROUP"

##### App Service Plan (From Command Line)
az deployment group create --resource-group "rg-globalaz2021-india-dev-001" --template-file asp.template.json --parameters asp.parameters.json

##### Copy the files to WSL2 so that I can execute the commands from Ubuntu