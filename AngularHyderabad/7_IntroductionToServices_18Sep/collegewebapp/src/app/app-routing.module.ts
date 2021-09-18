import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'employees',
    loadChildren: () => import('./components/employees/employees.module').then(m => m.EmployeesModule),
  },
  {
    path: 'professors',
    loadChildren: () => import('./components/professors/professors.module').then(m => m.ProfessorsModule),
  },
  { path: '', redirectTo: 'home/dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'home/pagenotfound', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
