import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SignupDoneComponent } from './signup-done.component';

describe('SignupDoneComponent', () => {
  let component: SignupDoneComponent;
  let fixture: ComponentFixture<SignupDoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SignupDoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SignupDoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
