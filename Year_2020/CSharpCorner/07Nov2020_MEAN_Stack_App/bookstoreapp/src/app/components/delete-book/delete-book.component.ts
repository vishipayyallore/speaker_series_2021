import { ActivatedRoute, Router } from '@angular/router';
import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { BooksService } from '../../services/books.service';
import { IBookDto } from '../../interfaces/book.Dto';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrls: ['./delete-book.component.css']
})
export class DeleteBookComponent implements OnInit {

  deleteBookDto: IBookDto;
  deleteBookForm: FormGroup;

  constructor(private route: ActivatedRoute, private bookstoreService: BooksService,
    private ngZone: NgZone, private router: Router, private formBuilder: FormBuilder, private toastr: ToastrService) {

    this.deleteBookForm = this.formBuilder.group({
      dateOfPublish: '',
      language: '',
      author: '',
      title: '',
      id: ''
    });
  }

  ngOnInit(): void {

    this.route.paramMap.subscribe(params => {

      this.bookstoreService.GetBookById(params.get('bookId'))
        .subscribe((deleteBookDto: IBookDto) => {

          this.deleteBookDto = deleteBookDto;
          console.log(`${this.deleteBookDto.title}`);
        });
    });
  }

  onBookstoreRemove(id: string): void {

    console.warn(`Product Delete Request for Id: ${id}`);

    this.bookstoreService.RemoveBookById(id)
         .subscribe(res => {

      console.log('Book Deleted!');
      this.toastr.success('Book Deleted !!!', 'Books Store');
      this.ngZone.run(() => this.router.navigateByUrl('/books'));
    });
  }

}
