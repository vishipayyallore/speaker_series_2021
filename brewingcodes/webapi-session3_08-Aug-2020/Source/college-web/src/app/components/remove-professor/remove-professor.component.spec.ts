import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveProfessorComponent } from './remove-professor.component';

describe('RemoveProfessorComponent', () => {
  let component: RemoveProfessorComponent;
  let fixture: ComponentFixture<RemoveProfessorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemoveProfessorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoveProfessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
