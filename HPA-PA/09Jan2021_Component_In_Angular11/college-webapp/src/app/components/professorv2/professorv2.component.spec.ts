import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Professorv2Component } from './professorv2.component';

describe('Professorv1Component', () => {
  let component: Professorv2Component;
  let fixture: ComponentFixture<Professorv2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Professorv2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Professorv2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
