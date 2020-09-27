import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, from } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { IBookDto } from '../interfaces/book.Dto';
import { IAddBookDto } from '../interfaces/addBook.Dto';

const baseUrl = "http://localhost:4000/api";
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private httpClient: HttpClient) {
  }

  // GET All Books
  GetAllBooks(): Observable<IBookDto[]> {

    console.log(`Get All Books request received.`);

    return this.httpClient
      .get<IBookDto[]>(`${baseUrl}/books`)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  // Retrieve Book By Id
  GetBookById(id: string): Observable<IBookDto> {

    console.log(`Get Book request received for ${id}`);

    return this.httpClient
      .get<IBookDto>(`${baseUrl}/books/${id}`)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  //Add Book
  AddBooks(bookstore: IAddBookDto): Observable<IAddBookDto> {

    console.log(`Adding New Book: ${JSON.stringify(bookstore)}`);

    return this.httpClient
      .post<IAddBookDto>(`${baseUrl}/books`, JSON.stringify(bookstore), httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      )
  }

  // Edit Book By Id
  EditBookById(id: string, bookstore: IBookDto) {

    console.log(`Edit Book request received for ${id} ${JSON.stringify(bookstore)}`);

    return this.httpClient
      .put<IBookDto>(`${baseUrl}/books/${id}`, JSON.stringify(bookstore), httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  RemoveBookById(id: string) {
    console.log(`Removed Book request received for ${id}`);
    return this.httpClient.delete<IBookDto>(`${baseUrl}/books/${id}`, httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      )
  }

  // Error handling
  errorHandler(error) {

    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
