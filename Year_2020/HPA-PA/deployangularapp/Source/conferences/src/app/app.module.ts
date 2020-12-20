import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {
  faStar as farStar,
  faAddressCard as farAddressCard,
  faCalendarAlt as farCalendarAlt
} from '@fortawesome/free-regular-svg-icons';
import { faStar as fasStar } from '@fortawesome/free-solid-svg-icons';
// Add icons to the library for convenient access in other components
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNavbarComponent } from './components/shared/top-navbar/top-navbar.component';
import { SideNavbarComponent } from './components/shared/side-navbar/side-navbar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AboutUsComponent } from './components/company/about-us/about-us.component';
import { ContactUsComponent } from './components/company/contact-us/contact-us.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    TopNavbarComponent,
    SideNavbarComponent,
    FooterComponent,
    PageNotfoundComponent,
    DashboardComponent,
    AboutUsComponent,
    ContactUsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary) {

    // Add multiple icons to the library
    library.addIcons(fasStar, farStar, farAddressCard, farCalendarAlt);
  }
}
