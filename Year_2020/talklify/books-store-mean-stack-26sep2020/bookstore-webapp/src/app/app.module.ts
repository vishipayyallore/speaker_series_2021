import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { BooksListComponent } from './components/books-list/books-list.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DeleteBookComponent } from './components/delete-book/delete-book.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';
import { FooterComponent } from './components/footer/footer.component';
import { PageNotfoundComponent } from './components/page-notfound/page-notfound.component';
import { SideNavbarComponent } from './components/side-navbar/side-navbar.component';
import { TopNavbarComponent } from './components/top-navbar/top-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    AddBookComponent,
    BooksListComponent,
    DashboardComponent,
    DeleteBookComponent,
    EditBookComponent,
    FooterComponent,
    PageNotfoundComponent,
    SideNavbarComponent,
    TopNavbarComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
