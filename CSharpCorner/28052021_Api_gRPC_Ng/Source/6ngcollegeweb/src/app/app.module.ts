import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNavbarComponent } from './components/shared/top-navbar/top-navbar.component';
import { RatingComponent } from './components/shared/rating/rating.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { EmployeesCardsComponent } from './components/employees/employees-cards/employees-cards.component';
import { EmployeesTableComponent } from './components/employees/employees-table/employees-table.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TopNavbarComponent,
    RatingComponent,
    PageNotfoundComponent,
    FooterComponent,
    DashboardComponent,
    EmployeesCardsComponent,
    EmployeesTableComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
