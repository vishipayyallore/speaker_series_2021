import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HomeModule } from './components/home/home.module';
import { SharedModule } from './components/shared/shared.module';
import { EmployeesModule } from './components/employees/employees.module';
import { ProfessorsModule } from './components/professors/professors.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HomeModule,
    SharedModule,
    EmployeesModule,
    ProfessorsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
