import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';

import { IBookDto } from 'src/app/interfaces/IBookDto';
import { BooksService } from '../../../services/books.service';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrls: ['./list-books.component.css']
})
export class ListBooksComponent implements OnInit, OnDestroy {

  //@ts-ignore
  booksList: IBookDto[];
  imageWidth = 50;
  imageMargin = 1;
  //@ts-ignore
  booksServiceSubscription: Subscription;

  // Dependency Injection (Construction Injection)
  constructor(private booksService: BooksService, private router: Router) {
  }

  ngOnInit(): void {

    this.booksServiceSubscription = this.booksService.getAllBooks()
      .subscribe((data: IBookDto[]) => {

        this.booksList = data;
        console.log(this.booksList);
      });
  }

  ngOnDestroy() {
    console.log('Destroying ...');
    this.booksServiceSubscription.unsubscribe()
  }
}
