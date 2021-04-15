SUBSCRIPTIONNAME="SwamyPKV VSPS"
RESOURCEGROUP="rg-globalaz2021-india-dev-001"
LocationName="EastUS"
STORAGEACCT="stglobalaz2021india001"
APPINSIGHTS="appi-globalaz2021-india-001"

FUNCTIONAPP="func-azcoretools-demo-dev-001"
APPSERVICEPLAN="asp-azcoretools-demo-dev-001"

az login
az account set --subscription "$SUBSCRIPTIONNAME"
az account show --output table
# az account list --output table

##### App Service Plan
az deployment group create --resource-group "rg-globalaz2021-india-dev-001" --template-file asp.template.json --parameters asp.parameters.json

##### Azure Function App
az functionapp create \
  --resource-group "$RESOURCEGROUP" --name "$FUNCTIONAPP" \
  --storage-account "$STORAGEACCT" --runtime node \
  --consumption-plan-location "$LocationName" --functions-version 3 \
  --app-insights "$APPINSIGHTS" --plan "asp-azcoretools-demo-dev-001" \
  --runtime node --os-type Windows

