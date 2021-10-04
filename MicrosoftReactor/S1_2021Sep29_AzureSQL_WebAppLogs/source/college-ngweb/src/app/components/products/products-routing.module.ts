import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListProductsComponent } from './list-products/list-products.component';

const routes: Routes = [
  { path: 'list-products', component: ListProductsComponent },
];

@NgModule({
  exports: [
    RouterModule
  ],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class ProductsRoutingModule { }
