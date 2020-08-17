import { TestBed } from '@angular/core/testing';

import { ProfessorsService } from './professors.service';

describe('ProfessorsService', () => {
  let service: ProfessorsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProfessorsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
