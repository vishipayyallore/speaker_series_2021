import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNavbarComponent } from './components/top-navbar/top-navbar.component';
import { ProfessorComponent } from './professor/professor.component';
import { Professorv1Component } from './professorv1/professorv1.component';
import { Professorv2Component } from './components/professorv2/professorv2.component';

@NgModule({
  declarations: [
    AppComponent,
    TopNavbarComponent,
    ProfessorComponent,
    Professorv1Component,
    Professorv2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
