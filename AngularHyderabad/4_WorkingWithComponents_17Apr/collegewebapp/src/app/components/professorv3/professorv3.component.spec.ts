import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Professorv3Component } from './professorv3.component';

describe('Professorv3Component', () => {
  let component: Professorv3Component;
  let fixture: ComponentFixture<Professorv3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Professorv3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Professorv3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
