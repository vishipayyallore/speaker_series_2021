import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditProfessorComponent } from './edit-professor.component';

describe('EditProfessorComponent', () => {
  let component: EditProfessorComponent;
  let fixture: ComponentFixture<EditProfessorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditProfessorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditProfessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
