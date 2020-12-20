import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { ListBooksComponent } from './components/list-books/list-books.component';
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
    ListBooksComponent,
    DashboardComponent,
    DeleteBookComponent,
    EditBookComponent,
    FooterComponent,
    PageNotfoundComponent,
    SideNavbarComponent,
    TopNavbarComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
