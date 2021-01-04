import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Professorv1Component } from './professorv1.component';

describe('Professorv1Component', () => {
  let component: Professorv1Component;
  let fixture: ComponentFixture<Professorv1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Professorv1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Professorv1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
