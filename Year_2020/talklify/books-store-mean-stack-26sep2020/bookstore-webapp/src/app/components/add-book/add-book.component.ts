'use strict';

import { Router } from '@angular/router';
import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { BooksService } from '../../services/books.service';
import { IAddBookDto } from '../../interfaces/addBook.Dto';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  // addBookDto: IAddBookDto;
  addBookForm: FormGroup;

  constructor(private bookstoreService: BooksService, private ngZone: NgZone,
    private router: Router, private formBuilder: FormBuilder) {

    this.addBookForm = this.formBuilder.group({
      dateOfPublish: '',
      language: '',
      author: '',
      title: ''
    });
  }

  ngOnInit(): void {
  }

  onBookAdd(bookData: IAddBookDto): void {

    this.bookstoreService.AddBooks(bookData).subscribe(res => {

      console.log('Book Added!')
      this.ngZone.run(() => this.router.navigateByUrl('/books'))
    });

  }

}
