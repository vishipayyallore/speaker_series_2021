import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PageNotfoundComponent } from './components/page-notfound/page-notfound.component';
import { ProfessorsListComponent } from './components/professors-list/professors-list.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'professors', component: ProfessorsListComponent },
  { path: 'pagenotfound', component: PageNotfoundComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'pagenotfound', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
