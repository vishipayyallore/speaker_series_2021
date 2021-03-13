import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProfessorV1Component } from './professorv1/professorv1.component';
import { ProfessorV2Component } from './professorv2/professorv2.component';
import { TopNavbarComponent } from './components/top-navbar/top-navbar.component';
import { ProfessorV3Component } from './components/professorv3/professorv3.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfessorV1Component,
    ProfessorV2Component,
    ProfessorV3Component,
    TopNavbarComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
