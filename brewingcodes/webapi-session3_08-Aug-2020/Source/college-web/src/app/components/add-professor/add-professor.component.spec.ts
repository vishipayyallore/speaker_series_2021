import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProfessorComponent } from './add-professor.component';

describe('AddProfessorComponent', () => {
  let component: AddProfessorComponent;
  let fixture: ComponentFixture<AddProfessorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddProfessorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProfessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
