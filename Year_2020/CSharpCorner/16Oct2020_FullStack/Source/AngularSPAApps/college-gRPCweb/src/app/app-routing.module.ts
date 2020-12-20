import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EditProfessorComponent } from './components/edit-professor/edit-professor.component';
import { PageNotfoundComponent } from './components/page-notfound/page-notfound.component';
import { ProfessorsListComponent } from './components/professors-list/professors-list.component';
import { RemoveProfessorComponent } from './components/remove-professor/remove-professor.component';
import { AddProfessorComponent } from './components/add-professor/add-professor.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'professors', component: ProfessorsListComponent },
  { path: 'add-professor', component: AddProfessorComponent },
  { path: 'edit-professor/:professorId', component: EditProfessorComponent },
  { path: 'remove-professor/:professorId', component: RemoveProfessorComponent },
  { path: 'pagenotfound', component: PageNotfoundComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'pagenotfound', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
