# ****************************************************** ******************************************************
SUBSCRIPTION="SwamyPKV VSPS"
RESOURCEGROUP="rg-az204-webapps-reactor-001"
LOCATION="eastus"
PLANNAME="plan-azsxdcfv2"
PLANSKU="F1"
SITENAME="app-azsxdcfv2"

az login
az account show -o table
az account set --subscription $SUBSCRIPTION
az group create --name $RESOURCEGROUP --location $LOCATION

az appservice plan create --name $PLANNAME --location $LOCATION --sku $PLANSKU --resource-group $RESOURCEGROUP
az webapp create --name $SITENAME --plan $PLANNAME --resource-group $RESOURCEGROUP

az webapp deployment source config-local-git --name "app-azsxdcfv2" --resource-group "rg-az204-webapps-reactor-001"
git clone https://$USERNAME@app-azsxdcfv2.scm.azurewebsites.net/app-azsxdcfv2.git

git add .
git commit -m "Initial Version"
git push

az webapp browse --name $SITENAME --resource-group $RESOURCEGROUP
# ****************************************************** ******************************************************
