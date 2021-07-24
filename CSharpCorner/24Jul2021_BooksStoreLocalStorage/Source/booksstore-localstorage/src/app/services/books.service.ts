import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Subscriber } from 'rxjs/internal/Subscriber';

import { LocalstorageService } from './localstorage.service';
import { IBookDto } from '../interfaces/IBookDto';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  booksList: IBookDto[] = [];

  constructor(private localStorageService: LocalstorageService) {
  }

  getAllBooks(): Observable<IBookDto[]> {

    //@ts-ignore
    this.booksList = JSON.parse(this.localStorageService.getItem('books'));

    return new Observable<IBookDto[]>(
      (subscriber: Subscriber<IBookDto[]>) => {
        setTimeout(() => {
          subscriber.next(this.booksList)
        }, 500);
      });

  }

}
