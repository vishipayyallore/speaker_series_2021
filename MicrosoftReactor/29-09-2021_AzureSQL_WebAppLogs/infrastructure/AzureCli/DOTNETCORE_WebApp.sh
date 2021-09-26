SUBSCRIPTION="SwamyPKV VSPS"
RESOURCEGROUP="rg-az204-webapps-reactor-001"
LOCATION="eastus"
PLANNAME="plan-api$(echo $RANDOM)"
PLANSKU="B1"
SITENAME="app-collegeapi$(echo $RANDOM)"
RUNTIME="DOTNET|6.0"

# az webapp list-runtimes --linux
# F1, FREE, D1, SHARED, B1, B2, B3, S1, S2, S3, P1V2, P2V2, P3V2, P1V3, P2V3, P3V3, PC2,PC3, PC4, I1, I2, I3, I1v2, I2v2, I3v2.

# create a resource group for your application
az group create --name $RESOURCEGROUP --location $LOCATION

# create an appservice plan (a machine) where your site will run
az appservice plan create --name $PLANNAME --location $LOCATION --is-linux --sku $PLANSKU --resource-group $RESOURCEGROUP

# create the web application on the plan
# specify the runtime version your app requires
az webapp create --name $SITENAME --plan $PLANNAME --runtime $RUNTIME --resource-group $RESOURCEGROUP
