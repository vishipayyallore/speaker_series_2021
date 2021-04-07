# Session **3 of 12** - Revisiting Components in Angular 11 for Beginners

> 1. Event Date: **13-Mar-2021**
> 1. Event URL: [Angular Hyderabad](https://www.meetup.com/nghyderabad/events/276845393/)

----------------------------------------------------------------------------------------------------------------

## Pre-Requisites

### Software/Tools
> 1. OS: win32 x64
> 1. Angular CLI: **11.2.3**
> 1. Node: **14.15.4**
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

### Previous Session's UI **(Session 2)**
![UI Look and Feel | 100x100](./Documentation/Images/UILook_N_Feel.PNG)

### Current Session's UI **(Session 3)**
![UI Look and Feel | 100x100](./Documentation/Images/UILook_N_Feel_Current.PNG)

----------------------------------------------------------------------------------------------------------------

## What are we doing today?
> 1. View the Session 2's deployed Web App in Firebase
> 2. Clean up the previous session's code
> 3. Component selector as directive
> 4. Structural Directives ```*ngIf```
> 6. Strong Type
> 5. Introduction to pipes
> 7. ```<ScriptTag>``` Demo
> 8. Data Types, Type Inference, Property Binding and Event Binding
> 9. Two-way Binding, and Template Varaible
> 10. Structural Directives - ```*ngFor```
> 11. Deploying Angular 11 application to Firebase

----------------------------------------------------------------------------------------------------------------

## How to Build and Execute the solution

### **1. View the Session 2's deployed Web App in Firebase**
Demo

### **2. Clean up the previous session's code**

> 1. Remove professorv1 & professorv2 Components. Also update the app.module.ts
> 1. Remove ```<i class="fa fa-car" aria-hidden="true"></i>``` from top-navbar.component.html
> 1. Remove the **Div** tag with camera icons from app.component.html.


### **3. Component selector as directive**
Discussion

### **4. Structural Directives ```*ngIf```**

> 1. Comment the code inside the constructor of professorv3.component.ts
> 1. We will see error in the Console windows of Dev Tools.
> 1. Add ```*ngIf``` to the **div** tag.
```
constructor() {
    /*
    this.professor = {
      professorId: 3,
      name: 'Hafeez',
      dateOfJoin: new Date(),
      salary: 1234.5678,
      isPhd: true
    };
    */
  }

    <div class="container rounded shadow first-div py-2" *ngIf="professor">
```

### **5. Strong Type**
> 1. Change the type of professor to any. ```professor: any;```
> 1. Change the property **salary** to **salaree**.
> 1. Component will be show any errors, also it will not display the salary
> 1. Change the type of professor to IProfessor. ```professor: IProfessor;```
> 1. Now the it will show the error message. ```Object literal may only specify known properties, and 'salaree' does not exist in type 'IProfessor'.```

```
  constructor() {
    this.professor = {
      professorId: 3,
      name: 'Hafeez',
      dateOfJoin: new Date(),
      **salaree**: 1234.5678,
      isPhd: true
    };
  }
```

### **6. Introduction to pipes**
> 1. lowercase
> 1. uppercase
> 1. date
> 1. currency
```
    <div class="container rounded shadow first-div py-2" *ngIf="professor">
        <h1>Professor {{professor.name}} (V3)</h1>
        <hr>
        <div>
            <p>Id: <span>{{professor.professorId}}</span></p>
            <p>Date Of Join: <span>{{professor.dateOfJoin | date | lowercase}}</span></p>
            <p>Salary: <span>{{professor.salary | currency:'INR':'symbol':'4.2-3'}}</span></p>
            <p>Is Phd: <span>{{professor.isPhd}}</span></p>
        </div>
    </div>
```

### **7. ```<ScriptTag>``` Demo**

> 1. Modify the name property to inject the ```<script>``` tag.

```
  constructor() {
    this.professor = {
      professorId: 3,
      **name: '<script>alert("Hello");</script>Hafeez',**
      dateOfJoin: new Date(),
      salary: 1234.5678,
      isPhd: true
    };
  }
```

### **8. Data Types, Type Inference, Property Binding and Event Binding**

> 1. Create a new component called **employee**. ```ng g c components/employee```

**Component to View**
```
<img scr='{{Intropolation}}'>
<img scr='http://www.website.com/{{Intropolation}}'>
<img [scr]='object.Property'>
```

**View to Component**
```
<button type='submit' (click)='methodName()'>
```

### **9. Two-way Binding, and Template Varaible**

> 1. Create a new component called **login**. ```ng g c components/login```

**Two Way**
> 1. <input type='text' [(ngModel)]='object.Property' #templateVariable>

### **10. Structural Directives - ```*ngFor```**
> 1. Create a new component called **professors-list**. ```ng g c components/professors-list```


### **11. Deploying Angular 11 application to Firebase**
> 1. Create a new project in FireBase.
> 1. Create a Hosting 
> 1. Create Cloud Firestore

**Ensure that you are specifying "dist/collegewebapp" as public folder**
```
install -g firebase-tools
ng build --prod
firebase login
ng add @angular/fire
firebase init
firebase deploy --only hosting:ng11-webapp (ng11-webapp === Firebase Project Name)
```

----------------------------------------------------------------------------------------------------------------

