RGName="rg-book-store"
LocationName="EastUS"
TemplateFilePath="./azuredeploy.json"
ParameterFilePath="./azuredeploy.parameters.json"
 
##### Deploy the Windows basic Web App
# az deployment group create --resource-group $RGName --template-file ./azuredeploy.json --parameters ./azuredeploy.parameters.json

az group create --name $RGName --location $LocationName
az deployment group create --resource-group $RGName --template-file $TemplateFilePath --parameters $ParameterFilePath