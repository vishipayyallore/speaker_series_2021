##### Variables when executing from Bash Shell
SubscriptionName="SwamyPKV VSPS"
RGName="rg-az204-webapps-reactor-001"
LocationName="EastUS"
BaseName="$RANDOM"
VmName="win$(echo $BaseName)" 
PortToOpen=80
username="demouser"
password="NoPassword@123$"
ImageName="Win2019Datacenter" 

##### Login
az login
az account set --subscription $SubscriptionName
az account list --output table
az account show

###### Group
az group list --output table
az group create --name $RGName --location $LocationName

##### Creating Virtual Machine
az vm create --resource-group $RGName --name $VmName --image $ImageName --public-ip-sku Standard --authentication-type password --admin-username $username --admin-password $password


##### Opending the ports
az vm open-port --resource-group $RGName --name $VmName --port $PortToOpen --priority 900

##### IP Addresses for Remote Access
az vm list-ip-addresses --resource-group $RGName --name $VmName --output table

##### Connect to Windows VM using RPD
mstsc /v:publicIpAddress

##### From Within the newly created VM
PS > Install-WindowsFeature -name Web-Server -IncludeManagementTools

# visit the URL
http://IpAddress-Of-Newly-Created-VM

az group delete -n $RGName

##### **************************
