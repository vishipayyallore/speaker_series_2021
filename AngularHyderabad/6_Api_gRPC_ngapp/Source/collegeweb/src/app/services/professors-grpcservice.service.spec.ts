import { TestBed } from '@angular/core/testing';

import { ProfessorsGrpcserviceService } from './professors-grpcservice.service';

describe('ProfessorsGrpcserviceService', () => {
  let service: ProfessorsGrpcserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfessorsGrpcserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
