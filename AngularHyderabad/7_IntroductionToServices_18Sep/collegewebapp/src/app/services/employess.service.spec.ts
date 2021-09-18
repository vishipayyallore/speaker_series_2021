import { TestBed } from '@angular/core/testing';

import { EmployessService } from './employess.service';

describe('EmployessService', () => {
  let service: EmployessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
