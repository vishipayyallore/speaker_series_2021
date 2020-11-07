import { Component, OnInit } from '@angular/core';

import { IBookDto } from '../../interfaces/book.Dto';
import { BooksService } from '../../services/books.service';

@Component({
  selector: 'app-list-books',
  templateUrl: './list-books.component.html',
  styleUrls: ['./list-books.component.css']
})
export class ListBooksComponent implements OnInit {

  booksList: IBookDto[];

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
