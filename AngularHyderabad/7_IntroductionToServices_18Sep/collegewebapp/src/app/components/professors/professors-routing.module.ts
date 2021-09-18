import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfessorsListComponent } from './professors-list/professors-list.component';
import { EditProfessorComponent } from './edit-professor/edit-professor.component';

const routes: Routes = [
  { path: '', component: ProfessorsListComponent },
  { path: 'edit/:professorId', component: EditProfessorComponent },
];

@NgModule({
  exports: [
    RouterModule
  ],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class ProfessorsRoutingModule { }
