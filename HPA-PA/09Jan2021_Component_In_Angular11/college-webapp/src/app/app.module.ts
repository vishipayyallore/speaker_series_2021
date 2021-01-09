import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { Professorv1Component } from './professorv1/professorv1.component';
import { Professorv2Component } from './professorv2/professorv2.component';
import { TopNavbarComponent } from './components/top-navbar/top-navbar.component';
import { Professorv3Component } from './components/professorv3/professorv3.component';

@NgModule({
  declarations: [
    AppComponent,
    Professorv1Component,
    Professorv2Component,
    TopNavbarComponent,
    Professorv3Component
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
