import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, from } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { ProfessorDto } from '../interfaces/professor.Dto';

const baseUrl = 'https://localhost:5002/api';
const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
    }),
};

@Injectable({
    providedIn: 'root',
})
export class ProfessorsService {
    constructor(private httpClient: HttpClient) { }

    // GET All Professors
    GetAllProfessors(): Observable<ProfessorDto[]> {
        return this.httpClient
            .get<ProfessorDto[]>(`${baseUrl}/professors`)
            .pipe(retry(1), catchError(this.errorHandler));
    }

    // GET
    GetProfessorById(id: string): Observable<ProfessorDto> {
        console.log(`Get Professor request received for ${id}`);
        return this.httpClient
            .get<ProfessorDto>(`${baseUrl}/professors/${id}`)
            .pipe(retry(1), catchError(this.errorHandler));
    }

    // UPDATE
    ModifyProfessorById(id: number, Professor: ProfessorDto) {
        console.log(
            `Update Professor request received for ${id} ${JSON.stringify(Professor)}`
        );
        return this.httpClient
            .put<ProfessorDto>(
                `${baseUrl}/professors/${id}`,
                JSON.stringify(Professor),
                httpOptions
            )
            .pipe(retry(1), catchError(this.errorHandler));
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
