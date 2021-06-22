import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCallsComponent } from './view-calls.component';

describe('ViewCallsComponent', () => {
  let component: ViewCallsComponent;
  let fixture: ComponentFixture<ViewCallsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewCallsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCallsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
