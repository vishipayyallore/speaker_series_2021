$LocationName = "EastUS"
$PublisherName = "MicrosoftWindowsServer"
$OfferName = "WindowsServer" # "windows-10-1607-vhd-server-prod-stage"
$SkuName = "2019-Datacenter"
$VersionNumber = "2019.0.20190410"

Get-AzVMImagePublisher -Location $LocationName | Select PublisherName
Get-AzVMImagePublisher -Location $LocationName | Where-Object { $_.PublisherName -Like "*windows*" } | Select PublisherName

Get-AzVMImageOffer -Location $LocationName -PublisherName $PublisherName | Select Offer

Get-AzVMImageSku -Location $LocationName -PublisherName $PublisherName -Offer $OfferName | Select Skus

Get-AzVMImage -Location $LocationName -PublisherName $PublisherName -Offer $OfferName -Skus $SkuName
Get-AzVMImage -Location $LocationName -PublisherName $PublisherName -Offer $OfferName -Skus $SkuName -Version $VersionNumber

##### Ubuntu
Get-AzVMImagePublisher -Location CentralUS | Where-Object { $_.PublisherName -Like "*Canonical*" } | Select PublisherName

Get-AzVMImageOffer -Location CentralUS -PublisherName Canonical | Select Offer

Get-AzVMImageSku -Location CentralUS -PublisherName Canonical -Offer UbuntuServer | Select Skus

Get-AzVMImage -Location CentralUS -PublisherName Canonical -Offer UbuntuServer -Skus "18.04-LTS"
