import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TopNavbarComponent } from './components/shared/top-navbar/top-navbar.component';
import { FormsModule } from '@angular/forms';
import { ProfessorsListComponent } from './components/professors/professors-list/professors-list.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { RatingComponent } from './components/shared/rating/rating.component';
import { EmployeesListComponent } from './components/employees/employees-list/employees-list.component';

@NgModule({
  declarations: [
    AppComponent,
    TopNavbarComponent,
    ProfessorsListComponent,
    FooterComponent,
    RatingComponent,
    EmployeesListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
