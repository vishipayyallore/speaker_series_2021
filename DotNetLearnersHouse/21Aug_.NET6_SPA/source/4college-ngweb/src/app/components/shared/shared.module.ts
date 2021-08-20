import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TopNavbarComponent } from './top-navbar/top-navbar.component';
import { FooterComponent } from './footer/footer.component';
import { PageNotfoundComponent } from './page-notfound/page-notfound.component';
import { SharedRoutingModule } from './shared-routing.module';

@NgModule({
  declarations: [
    TopNavbarComponent,
    FooterComponent,
    PageNotfoundComponent,
  ],
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  exports: [
    TopNavbarComponent,
    FooterComponent,
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class SharedModule { }
