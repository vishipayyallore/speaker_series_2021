# Azure Web Apps (.NET 5 Web API), Azure SQL, App Settings and Connection String 29-Sep-2021 at 09:00 AM IST

## Event URL: [https://www.meetup.com/microsoft-reactor-bengaluru/events/280816393](https://www.meetup.com/microsoft-reactor-bengaluru/events/280816393) 

![Viswanatha Swamy P K |150x150](./documentation/images/ViswanathaSwamy_29thSept.PNG)

---


## Application Architecture Diagram 

![Application Architecture 29-Sep-2021 |150x150](./documentation/images/AppArchitecture_29thSep.PNG)

---

## Resources in Azure

```
To Be Done
```

## Information
![Information | 100x100](./documentation/images/Information.PNG)

## What are we doing today?
> 1. Creating Web App, and deploying it using PowerShell
> 1. Creating Web App Azure CLI (Cloud Shell) and deploying using VS 2019
> 1. Creating the Web App using ARM template using cloud shell, and deploying using VS 2019
> 1. Creating Azure SQL Server and Database. Deploying .SQLPROJ to Azure SQL
> 1. Connecting Azure SQL from Local Web API
> 1. Deploying the Web API changes to Web App
> 1. Configuring the SQL Azure Connection String in App Settings in Azure
> 1. Verifying the Web API using Postman
> 1. SUMMARY / RECAP / Q&A 

![Seat Belt | 100x100](./documentation/images/SeatBelt.PNG)

*****

## 1. Creating Web App, and deploying it using PowerShell
> 1. To be done
>    1. Manual
>    1. Automated

## 2. Creating Web App Azure CLI (Cloud Shell) and deploying using VS 2019
> 1. Discussion on Cloud Shell
> 1. Discussion on VS code `Azure Extensions`
> 1. Discussion on VS 2019 `Cloud Explorer`


```
dotnet publish -c release -o ./publish
```

![VS Code Deploy 1 | 100x100](./documentation/images/DeployUsingVSCode.PNG)

## 3. Creating the Web App using ARM template using cloud shell, and deploying using VS 2019

> 1. To be done

```
dotnet publish -c release -o ./publish

ls -a
```


![VS Code Deploy 2 | 100x100](./documentation/images/DeployUsingVSCode_Lnx.PNG)

## 4. Creating Azure SQL Server and Database. Deploying .SQLPROJ to Azure SQL
> 1. To be done

```
az login

az account show -o table

az webapp list-runtimes

az webapp up --location EastUs --name hellohtml04092021 --resource-group rg-az204-webapps-reactor-001 --html
```

![az webapp up | 100x100](./documentation/images/WebAppUp_Html.PNG)


## 5. Connecting Azure SQL from Local Web API

> 1. To be done

![Azure CLI Commands | 100x100](./documentation/images/DeployUsing_AzureCLI_1.PNG)


## 5. Connecting Azure SQL from Local Web API

> 1. To be done

![Azure CLI Commands | 100x100](./documentation/images/DeployUsing_AzureCLI_1.PNG)

## 6. Deploying the Web API changes to Web App

## 7. Configuring the SQL Azure Connection String in App Settings in Azure

## 8. Verifying the Web API using Postman

## 9. SUMMARY / RECAP / Q&A 

*****
> 1. SUMMARY / RECAP / Q&A 
> 2. Any open queries, I will get back through meetup chat/twitter.
*****

## What is Next? (`Session 2` of `Azure App Services` on 29-Sep-2021)
> 1. To be done
