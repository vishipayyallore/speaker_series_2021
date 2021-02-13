# Session on Deploying Angular 11 to Azure and Firebase

## Tech Stack
> 1. Angular CLI (version **11.1.2**).

## Upgrade the Angular Cli/Core
```
ng update @angular/cli @angular/core
```

## UI Look and Feel


## Angular 11 Application

```
ng new conferences
```

## Dashboard

### Creating New Components
```
ng g c components/shared/top-navbar
ng g c components/shared/side-navbar
ng g c components/shared/footer
ng g c components/shared/page-notfound

ng g c components/dashboard
```

## Deploying to Azure

**Resource In Azure**
> 1. rsg_conferences-ngui-dev
> 1. asp-conferences-ngui-dev
> 1. app-conferences-ngui-dev

https://YourApp.scm.azurewebsites.net:443/YourApp.git
UserName
Password

Commands
```
az login
az webapp deployment user set --user-name UserName --password Password
```

```
git clone https://YourApp.scm.azurewebsites.net:443/YourApp.git
```

Generate the production version of build
```
ng build --prod
```

**Copy from build output folder into the YourApp**

```
git add .
git commit -m "ase deploy with localgit"
git push
```

## Deploying Angular 11 application to Firebase
> 1. Create a new project in FireBase.
> 1. Create a Hosting 
> 1. Create Cloud Firestore

**Ensure that you are specifying "dist/conferences" as public folder**
```
install -g firebase-tools
firebase login
ng add @angular/fire
firebase init
ng build --prod
firebase deploy --only hosting:YourProjectName
```






