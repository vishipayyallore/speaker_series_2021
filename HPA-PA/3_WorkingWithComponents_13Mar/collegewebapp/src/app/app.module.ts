import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TopNavbarComponent } from './components/top-navbar/top-navbar.component';
import { ProfessorV3Component } from './components/professorv3/professorv3.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule } from '@angular/forms';
import { ProfessorsListComponent } from './components/professors-list/professors-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfessorV3Component,
    TopNavbarComponent,
    EmployeeComponent,
    LoginComponent,
    ProfessorsListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
