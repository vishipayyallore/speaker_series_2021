SUBSCRIPTIONNAME="SwamyPKV VSPS"
RESOURCEGROUP="rg-globalaz2021-india-dev-001"
LocationName="EastUS"
STORAGEACCT="stglobalaz2021india001"
APPINSIGHTS="appi-globalaz2021-india-001"

az login
az account set --subscription "$SUBSCRIPTIONNAME"
az account show --output table
# az account list --output table

###### Group
az group list --output table
az group create --name "$RESOURCEGROUP" --location "$LocationName"

##### Storage Account
az storage account create --resource-group "$RESOURCEGROUP" \
  --name "$STORAGEACCT" --kind StorageV2 --location "$LocationName"

##### Application Insights
az monitor app-insights component create --app "$APPINSIGHTS" --location "$LocationName" --resource-group "$RESOURCEGROUP"

