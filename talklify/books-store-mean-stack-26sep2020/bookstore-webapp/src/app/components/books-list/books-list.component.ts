import { Component, OnInit } from '@angular/core';

import { IBookDto } from '../../interfaces/book.Dto';
import { BooksService } from '../../services/books.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {

  booksList: IBookDto[] = [];

  constructor(private booksService: BooksService) {
  }

  ngOnInit(): void {

    this.retrieveAllBooks();
  }

  retrieveAllBooks() {

    this.booksService.GetAllBooks()
      .subscribe((data: IBookDto[]) => {

        this.booksList = data;
        console.log(this.booksList);
      });
  }

}
