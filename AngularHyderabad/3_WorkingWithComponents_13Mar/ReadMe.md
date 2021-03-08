# Session **3 of 12** - Revisiting Components in Angular 11 for Beginners

> 1. Event Date: **13-Mar-2021**
> 1. Event URL: [Angular Hyderabad](https://www.meetup.com/nghyderabad/events/ToBeDone)

----------------------------------------------------------------------------------------------------------------

## Pre-Requisites

### Software/Tools
> 1. OS: win32 x64
> 1. Angular CLI: **11.2.0**
> 1. Node: **14.15.5**
> 1. Visual Studio Code

### Prior Knowledge
> 1. Html, CSS
> 1. Type Script
> 1. Java Script
> 1. Basic Angular

### Assumptions
> 1. NIL

## Technology Stack
> 1. Single Page Application using Angular 11

## Upgrade the Angular Cli/Core
```
ng update @angular/cli @angular/core
```

## Information
![Information | 100x100](./Documentation/Images/Information.PNG)

## UI Look and Feel
![UI Look and Feel | 100x100](./Documentation/Images/UILook_N_Feel.PNG)

----------------------------------------------------------------------------------------------------------------

## What are we doing today?
> 1. We will be working on the Project we developed in Session 2.
> 1. Data Types and Type Inference
> 1. Strong Type errors any[] VS IProfessor[]
> 1. Component selector as directive
> 1. Introduction to pipes
> 1. Property Binding 
> 1. Event Binding 
> 1. Two-way Binding 
> 1. Template Varaible
> 1. Structural Directives - *ngIf 
> 1. Structural Directives - *ngFor
> 1. Deploying the Angular application to Firebase

----------------------------------------------------------------------------------------------------------------

Property Binding
<img scr='{{Intropolation}}'>
<img scr='http://www.website.com/{{Intropolation}}'>
<img [scr]='object.Property'>

**Component to View**
> 1. {{Intropolation}}
> 1. <img [scr]='object.Property'>

**View to Component**
> 1. <button type='submit' (click)='methodName()'>

**Two Way**
> 1. <input type='text' [(ngModel)]='object.Property'>

Pipes

> 1. lowercase
> 1. uppercase
> 1. date
> 1. currency
> 1. {{ product.price | currency | lowercase }}

----------------------------------------------------------------------------------------------------------------

## How to Build and Execute the solution

### **1. Create new Project and Execute**
```
ng new collegewebapp
npm start
```

### Few changes to the Project

1. Modify **package.json** to open the browser during execution
> ```
> "start": "ng serve -o",
> ```

2. Install **bootstrap** and **font-awesome**
> ```
> npm i bootstrap
> npm i font-awesome
> ```

3. Modify **angular.json** to import CSS
> ```
> "styles": [
>     "src/styles.css",
>     "./node_modules/font-awesome/css/font-awesome.css",
>     "./node_modules/bootstrap/dist/css/bootstrap.css"
> ],
> ```

4. Modify **angular.json** to change the default port **4200** to your choice of port **xxxx**
> ```
> "serve": {
>     "builder": "@angular-devkit/build-angular:dev-server",
>     "options": {
>         "browserTarget": "college-webapp:build",
>         "port": 4004
>     },
> }
> ```

5. Clean up the **src/app/app.component.html** and add a **h1** Tag
> ```
> <h1>Hello World !!!</h1>
> ```

6. Execute the **npm start** to view **Hello World !!!**

### What is a Component? 
Discussion

### Module, Decorator, Metadata. 
Discussion

### Bootstrapping AppComponent. 
Discussion

### **2. Creating Component with Inline Template [Manual]**
> 1. Copy **interfaces** folder from **StarterFiles** folder into **src/app** folder.
> 1. Create **professorv1/professorv1.component.ts** folder insde **src/app** folder.
> 1. Selector, Template, Styles
> 1. Interpolation (One-way binding) Bind 
> 1. Modify the professorv1.component.ts file. Please refer to **StarterFiles** folder.
> 1. Add **Professorv1Component** inside declarations in app.module.ts file.
> 1. Update app.component.html to include **professorv1** (Component as a directive).
> 1. Run **npm start** to view the **Version 1** of Professors component.

**ng g** commands for reference
```
ng g interface interfaces/IProduct --dry-run
```

```
declarations: [
    AppComponent,
    Professorv1Component,
],
```

```
<div class="container row col-sm-12 py-2">
    <app-professorv1 class="px-2"></app-professorv1>
</div>
```

### **3. Creating Top Navigation Bar**
> 1. Create a Component using **ng g c** CLI Command
> 1. Modify **top-navbar.component.html** file. Please refer **StarterFiles** folder.
> 1. Modify **styles.css** file. Please refer **StarterFiles** folder.
> 1. Update app.component.html to include **top-navbar**.
> 1. Run **npm start** to view the **top-navbar** of Professors component.

```
    ng g c components/top-navbar --dry-run
```

```
<app-top-navbar></app-top-navbar>

<div class="container row col-sm-12 py-2">
    <app-professorv1 class="px-2"></app-professorv1>
</div>
```

### **4. Creating Component with Linked Template [Manual]** 
> 1. Create **professorv2** folder insde **src/app** folder.
> 1. Selector, TemplateUrl, StyleUrls
> 1. Create three files (professorv2.component.ts, professorv2.component.html, professorv2.component.css) inside **proferssorv2** folder.
> 1. Modify the three files. Please refer **professorv2** folder inside **StarterFiles** folder.
> 1. Add **Professorv2Component** inside declarations in app.module.ts file.
> 1. Update app.component.html to include **professorv2**.
> 1. Modify app.component.html to display both divs side-by-side.
> 1. Please refer **StarterFiles** folder.
> 1. Run **npm start** to view the **Version 1** and **Version 2** of Professors component.

```
declarations: [
    AppComponent,
    Professorv1Component,
    Professorv2Component,
],
```

### **5. Creating Component using ng g c CLI**
> 1. Create a Compoent using **ng g c** CLI Command
> 1. Modify the files (professorv3.component.ts, professorv3.component.html) inside **src/app/components/proferssorv3** folder.
> 1. Please refer **StarterFiles** folder.
> 1. Update app.component.html to include **professorv3**.
> 1. Run **npm start** to view the **All Three versions** of Professors component.

```
    ng g c components/professorv3
```

```
declarations: [
    AppComponent,
    Professorv1Component,
    Professorv2Component,
    Professorv3Component,
],
```

### **6. Importing CSS inside styles.css**
> 1. Remove the CSS definition from **angular.json**

> 1. Importing the CSS files inside **styles.css**
```
@import "../node_modules/font-awesome/css/font-awesome.css";
@import "../node_modules/bootstrap/dist/css/bootstrap.css";
```

### **7. Adding Icon to Top Nav Bar, and Body Background style**

> 1. Adding Icon to Top Nav Bar
```
<i class="fa fa-university"></i>
```

> 1. Back groud design
```
body {
  background-color: #b9cdf1;
  background-image: url("ThePattern");  
}

```

----------------------------------------------------------------------------------------------------------------

### **8. Deploying Angular 11 application to Firebase**
> 1. Create a new project in FireBase.
> 1. Create a Hosting 
> 1. Create Cloud Firestore

**Ensure that you are specifying "dist/collegewebapp" as public folder**
```
install -g firebase-tools
firebase login
ng add @angular/fire
firebase init
ng build --prod
firebase deploy --only hosting:YourProjectName
```

