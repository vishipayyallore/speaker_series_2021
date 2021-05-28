import { TestBed } from '@angular/core/testing';

import { ProfessorsApiserviceService } from './professors-apiservice.service';

describe('ProfessorsApiserviceService', () => {
  let service: ProfessorsApiserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfessorsApiserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
