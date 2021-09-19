import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactusComponent } from './contactus/contactus.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PageNotfoundComponent } from './page-notfound/page-notfound.component';


@NgModule({
  declarations: [
    AboutusComponent,
    ContactusComponent,
    DashboardComponent,
    PageNotfoundComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
