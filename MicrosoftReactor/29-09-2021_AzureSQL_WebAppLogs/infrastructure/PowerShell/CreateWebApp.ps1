# Create variables
$webappname = "collegeapi-$(Get-Random)"
$rgname = 'rg-az204-webapps-reactor-001'
$location = 'eastus'
$tier = 'Basic' # 'Free'

# Create a resource group
New-AzResourceGroup -Name $rgname -Location $location

# Create an App Service plan in S1 tier
New-AzAppServicePlan -Name $webappname -Location $location -ResourceGroupName $rgname -Linux -Tier $tier

# Create a web app
New-AzWebApp -Name $webappname -Location $location -AppServicePlan $webappname -ResourceGroupName $rgname
