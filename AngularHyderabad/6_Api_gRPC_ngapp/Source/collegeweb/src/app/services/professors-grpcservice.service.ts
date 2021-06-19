import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

import { ProfessorsGrpcDto } from '../interfaces/professor-dto';
import { environment } from 'src/environments/environment';

import { CollegeSvcClient, ServiceError } from '../proto/college_pb_service';
import { AllProfessorsResonse } from '../proto/college_pb';
import { Empty } from 'google-protobuf/google/protobuf/empty_pb';
import { BrowserHeaders } from 'browser-headers';

const headers = new BrowserHeaders({
    "content-type": "application/json"
});

@Injectable({
    providedIn: 'root',
})
export class ProfessorsGrpcserviceService {

    gRpcClient: CollegeSvcClient;

    constructor() {
        this.gRpcClient = new CollegeSvcClient(environment.gRPCUrl);
    }

    GetAllProfessorsFromgRPC(): Promise<object> {

        return new Promise((resolve, reject) => {

            this.gRpcClient.getAllProfessors(new Empty(), headers, (err: ServiceError | null, response: AllProfessorsResonse | null) => {
                if (err) {

                    console.log(`Error while invoking gRPC: ${err}`);
                    return reject(err);

                } else {

                    const allProfessors = response?.getProfessorsList();
                    console.log(`Inside Service: ${JSON.stringify(allProfessors)}`);

                    if (response !== null) {
                        return resolve(response.toObject());
                    }

                    return resolve({});
                }
            });

        });

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
