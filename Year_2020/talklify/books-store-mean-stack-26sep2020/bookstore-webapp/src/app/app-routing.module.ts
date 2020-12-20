import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddBookComponent } from './components/add-book/add-book.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DeleteBookComponent } from './components/delete-book/delete-book.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';
import { PageNotfoundComponent } from './components/page-notfound/page-notfound.component';

const routes: Routes = [
  { path: 'add-book', component: AddBookComponent },
  { path: 'books', component: BooksListComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'delete-book/:bookId', component: DeleteBookComponent },
  { path: 'edit-book/:bookId', component: EditBookComponent },
  { path: 'pagenotfound', component: PageNotfoundComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'pagenotfound', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
