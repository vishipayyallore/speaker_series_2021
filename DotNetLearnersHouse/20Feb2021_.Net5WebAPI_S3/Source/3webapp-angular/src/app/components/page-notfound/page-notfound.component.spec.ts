import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { PageNotfoundComponent } from './page-notfound.component';

describe('PageNotfoundComponent', () => {
  let component: PageNotfoundComponent;
  let fixture: ComponentFixture<PageNotfoundComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ PageNotfoundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageNotfoundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
