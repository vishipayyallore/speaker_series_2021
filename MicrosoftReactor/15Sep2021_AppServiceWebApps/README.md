# Hands-on Creating Azure App Service Web Apps 15-Sep-2021 at 09:00 AM IST

## Event URL: [https://www.meetup.com/microsoft-reactor-bengaluru/events/280462794/](https://www.meetup.com/microsoft-reactor-bengaluru/events/280462794/) 

![Viswanatha Swamy P K |150x150](./documentation/images/ViswanathaSwamy_15thSept.PNG)

---


## Application Architecture Diagram 

![Application Architecture](./documentation/images/ApplicationArchitecture.PNG "N-Tier Full Stack Application in Azure")

---

## Resources in Azure

![Resource In Azure|150x150](./documentation/images/ResourcesInAzure.PNG)

## Information
![Information | 100x100](./documentation/images/Information.PNG)

## What are we doing today?
> 1. App Service Plans
> 1. Creating Web App (Linux) in Portal, and deploying it from VS Code
> 1. Checking the code into GitHub.
> 1. Creating Web App (Windows) using Azure CLI, and deploying using Azure CLI.
> 1. Creating the Web App using ARM template using cloud shell, and deploying using VS 2019.


![Seat Belt | 100x100](./documentation/images/SeatBelt.PNG)

*****

## 1. Introduction to Azure App Service
> 1. App Service Overview
> 1. App Service Plans
> 1. Pricing Tiers
> 1. Ways to Deploy code to App Service
Automated
Manual

## 2. Creating Web App (Windows) in Portal, and deploying it from VS Code
> 1. Creating Web App (Windows) in Portal
> 1. Web API using .NET 5
> 1. Execute the below mentioned code to publish the binaries into a folder
> 1. Deploying it from VS Code


```
dotnet publish -c release -o ./publish
```

![VS Code Deploy 1 | 100x100](./documentation/images/DeployUsingVSCode.PNG)

## 3. Creating Web App (Linux) in Portal, and deploying it from VS Code

> 1. Creating Web App (Linux) in Portal
> 1. Web API using .NET 5
> 1. Execute the below mentioned code to publish the binaries into a folder
> 1. Deploying it from VS Code


```
dotnet publish -c release -o ./publish
```

![VS Code Deploy 1 | 100x100](./documentation/images/DeployUsingVSCode_Lnx.PNG)

## 4. Create a static HTML web app using `az webapp up`
> 1. Walk through of the Html App
> 1. Login using `az login`
> 1. Verify the account `az account show`
> 1. Execute the `az webapp up`

```
az login

az account show

az webapp up --location EastUs --name hellohtml04092021 --resource-group rg-az204-webapps-reactor-001
 --html
```

![VS Code Deploy 1 | 100x100](./documentation/images/WebAppUp_Html.PNG)

## 5. Creating Web App, and deploying it using PowerShell


## 6. Creating Web App, and deploying it using Azure CLI


## 7. Creating the Web App using ARM template using cloud shell, and deploying using VS 2019


## 8. Creating Web App (Linux) in Portal, and deploying it from VS Code


## 8. SUMMARY / RECAP / Q&A 

*****
> 1. SUMMARY / RECAP / Q&A 
> 2. Any open queries, I will get back through meetup chat/twitter.
*****