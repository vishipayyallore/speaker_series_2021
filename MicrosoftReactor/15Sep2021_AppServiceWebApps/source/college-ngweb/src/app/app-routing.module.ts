import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'products',
    loadChildren: () => import('./components/products/products.module').then(m => m.ProductsModule),
  },
  { path: '', redirectTo: 'home/dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'home/pagenotfound', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
