import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { IEmployee } from '../interfaces/iemployee';

const baseUrl = 'http://localhost:3000';

@Injectable({
  providedIn: 'root'
})
export class EmployessService {

  constructor(private httpClient: HttpClient) {
  }

  getAllEmployees(): Observable<IEmployee[]> {

    console.log(`Get All Employees request received.`);

    return this.httpClient
      .get<IEmployee[]>(`${baseUrl}/employees`)
      .pipe(retry(1), catchError(this.errorHandler));

  }

  // Error handling
  errorHandler(error: any) {

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
