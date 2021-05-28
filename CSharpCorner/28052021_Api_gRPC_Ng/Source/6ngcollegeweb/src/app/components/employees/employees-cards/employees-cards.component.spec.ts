import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesCardsComponent } from './employees-cards.component';

describe('EmployeesCardsComponent', () => {
  let component: EmployeesCardsComponent;
  let fixture: ComponentFixture<EmployeesCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeesCardsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeesCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
