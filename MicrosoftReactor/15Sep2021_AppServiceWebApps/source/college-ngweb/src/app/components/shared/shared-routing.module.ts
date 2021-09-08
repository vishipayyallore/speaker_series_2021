import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotfoundComponent } from './page-notfound/page-notfound.component';

const routes: Routes = [
  { path: '', component: PageNotfoundComponent },
];

@NgModule({
  exports: [
    RouterModule
  ],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class SharedRoutingModule { }
