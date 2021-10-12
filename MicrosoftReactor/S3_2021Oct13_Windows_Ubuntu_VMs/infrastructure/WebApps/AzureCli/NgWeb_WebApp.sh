# ****************************************************** ******************************************************
SUBSCRIPTION="SwamyPKV VSPS"
RESOURCEGROUP="rg-az204-webapps-reactor-001"
LOCATION="eastus"
PLANNAME="plan-collegeweb"
PLANSKU="F1"
SITENAME="app-collegeweb"

az login
az account show -o table
az account set --subscription $SUBSCRIPTION
az group create --name $RESOURCEGROUP --location $LOCATION

az appservice plan create --name $PLANNAME --location $LOCATION --sku $PLANSKU --resource-group $RESOURCEGROUP
az webapp create --name $SITENAME --plan $PLANNAME --resource-group $RESOURCEGROUP

az webapp deployment source config-local-git --name $SITENAME --resource-group $RESOURCEGROUP

# Inside dist folder
git clone https://app-collegeweb.scm.azurewebsites.net:443/app-collegeweb.git

git add .
git commit -m "Initial Version"
git push

az webapp browse --name $SITENAME --resource-group $RESOURCEGROUP
# ****************************************************** ******************************************************
