import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { ProfessorDtoApi } from '../interfaces/professor-dto';
import { environment } from 'src/environments/environment';

const baseUrl = environment.webApiUrl;
const apiName = 'professors';

@Injectable({
  providedIn: 'root',
})
export class ProfessorsApiserviceService {

  constructor(private httpClient: HttpClient) { }

  // GET All Professors
  GetAllProfessors(): Observable<ProfessorDtoApi[]> {
    return this.httpClient
      .get<ProfessorDtoApi[]>(`${baseUrl}/${apiName}`)
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
