import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from "@angular/common/http/testing";

import { ProfessorsService } from './professors.service';
import { HttpClient } from '@angular/common/http';

describe('ProfessorsService', () => {

    // let httpTestingController: HttpTestingController;
    let service: ProfessorsService;
    let httpClient: HttpClient;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [ProfessorsService]
        });

        // httpTestingController = TestBed.get(HttpTestingController);
        service = TestBed.inject(ProfessorsService);
        // httpClient = TestBed.inject(HttpClient);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
