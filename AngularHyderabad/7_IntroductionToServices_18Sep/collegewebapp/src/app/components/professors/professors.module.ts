import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfessorsRoutingModule } from './professors-routing.module';
import { ProfessorsListComponent } from './professors-list/professors-list.component';
import { EditProfessorComponent } from './edit-professor/edit-professor.component';

@NgModule({
  declarations: [
    ProfessorsListComponent,
    EditProfessorComponent
  ],
  imports: [
    CommonModule,
    ProfessorsRoutingModule
  ]
})
export class ProfessorsModule { }
