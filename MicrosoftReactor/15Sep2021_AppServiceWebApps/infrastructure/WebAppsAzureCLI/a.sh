#!/bin/bash

webAppName=azuremol$RANDOM
SUBSCRIPTION="SwamyPKV VSPS"
RESOURCEGROUP="rg-msft-reactor-1509-2021"
LOCATION="eastus"
PLANNAME="plan-collegeapi"
PLANSKU="F1"
SITENAME="app-collegeapi"
RUNTIME="DOTNETCORE|6.0"

az group create --name $RESOURCEGROUP --location $LOCATION

az appservice plan create \
    --resource-group $RESOURCEGROUP \
    --name $PLANNAME \
    --sku $PLANSKU

az webapp create \
    --resource-group $RESOURCEGROUP \
    --name $webAppName \
    --plan $PLANNAME \
    --deployment-local-git

git init && git add . && git commit -m "Initial Commit"

git remote add azure $(az webapp deployment source config-local-git \
    --resource-group $RESOURCEGROUP \
    --name $webAppName -o tsv)

git push azure master

hostName=$(az webapp show --resource-group $RESOURCEGROUP --name $webAppName --query defaultHostName --output tsv)

# Now you can access the Web App in your web browser
echo "To see your Web App in action, enter the following address in to your web browser:" $hostName
