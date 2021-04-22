import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewWorkingPlanComponent } from './view-working-plan.component';

describe('ViewWorkingPlanComponent', () => {
  let component: ViewWorkingPlanComponent;
  let fixture: ComponentFixture<ViewWorkingPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewWorkingPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewWorkingPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
