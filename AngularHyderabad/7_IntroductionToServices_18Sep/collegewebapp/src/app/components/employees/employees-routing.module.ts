import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EmployeesListComponent } from './employees-list/employees-list.component';

const routes: Routes = [
  { path: '', component: EmployeesListComponent },
];

@NgModule({
  exports: [
    RouterModule
  ],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class EmployeesRoutingModule { }
