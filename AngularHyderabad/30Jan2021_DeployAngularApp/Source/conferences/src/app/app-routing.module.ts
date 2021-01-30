import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AboutUsComponent } from './components/company/about-us/about-us.component';
import { ContactUsComponent } from './components/company/contact-us/contact-us.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: '**', component: PageNotfoundComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
