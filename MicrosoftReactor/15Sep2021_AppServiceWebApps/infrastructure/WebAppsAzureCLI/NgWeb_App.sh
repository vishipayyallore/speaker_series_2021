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

# To set up deployment from a local git repository, uncomment the following commands.
# first, set the username and password (use environment variables!)
# USERNAME="$webdeployuser"
# PASSWORD="Sample123$"
# az webapp deployment user set --user-name $USERNAME --password $PASSWORD


USERNAME="webdeployuser"
PASSWORD=""
az webapp deployment user set --user-name $USERNAME --password $PASSWORD

az webapp deployment user set --user-name "$webdeployuser" --password ""
az webapp deployment source config-local-git --name "app-azsxdcfv2" --resource-group "rg-az204-webapps-reactor-001"

git clone https://$app-azsxdcfv2@app-azsxdcfv2.scm.azurewebsites.net/app-azsxdcfv2.git
git remote add azure https://$app-azsxdcfv2@app-azsxdcfv2.scm.azurewebsites.net/app-azsxdcfv.git

# now, configure the site for deployment. in this case, we will deploy from the local git repository
# you can also configure your site to be deployed from a remote git repository or set up a CI/CD workflow
az webapp deployment source config-local-git --name $SITENAME --resource-group $RESOURCEGROUP

az webapp deployment user set --user-name $webdeployuser --password Sample123$

az webapp deployment source config-local-git --name "app-azsxdcfv" --resource-group "rg-az204-webapps-reactor-001"
git clone https://$app-azsxdcfv@app-azsxdcfv.scm.azurewebsites.net/app-azsxdcfv.git
git remote add azure https://$app-azsxdcfv@app-azsxdcfv.scm.azurewebsites.net/app-azsxdcfv.git

Output: https://$webdeployuser@app-aassddff.scm.azurewebsites.net/app-aassddff.git
# the previous command returned the git remote to deploy to
# use this to set up a new remote named "azure"
git remote add azure "https://$USERNAME@$SITENAME.scm.azurewebsites.net/$SITENAME.git"

git remote add azure https://$app-azsxdcfv@app-azsxdcfv.scm.azurewebsites.net/app-azsxdcfv.git

# push master to deploy the site
git push azure master

# browse to the site
az webapp browse --name $SITENAME --resource-group $RESOURCEGROUP
