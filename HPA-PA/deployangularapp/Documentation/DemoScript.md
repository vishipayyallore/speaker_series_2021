# Session on Deploying Angular 11 to Azure and Firebase

## Tech Stack
> 1. Angular (version **11.0.3**).

## Upgrade the Angular Cli/Core
```
ng update @angular/cli @angular/core
```

## Angular 11 Application

```
ng new conferences
```

## Dashboard

### Creating New Components
```
ng g c components/side-navbar
ng g c components/top-navbar
ng g c components/footer
ng g c components/page-notfound
ng g c components/dashboard
```

## Deploying to Azure

**Resource In Azure**
> 1. rsg_conferences-ngui-dev
> 2. asp-conferences-ngui-dev
> 3. app-conferences-ngui-dev

https://YourApp.scm.azurewebsites.net:443/YourApp.git
UserName
Password

Commands
```
az login
az webapp deployment user set --user-name UserName --password Passowrd
```

```
git clone https://YourApp.scm.azurewebsites.net:443/YourApp.git
```

```
git add .
git commit -m "ase deploy with localgit"
git push
```

```
ng build — prod
```
**Copy from build output folder into the YourApp**

```
git add .
git commit -m "ase deploy with localgit"
git push
```

## Deploying Angular 11 application to Firebase

```
install -g firebase-tools
firebase login
ng add @angular/fire
firebase init
ng build --prod
firebase deploy --only hosting:YourProjectName
```






