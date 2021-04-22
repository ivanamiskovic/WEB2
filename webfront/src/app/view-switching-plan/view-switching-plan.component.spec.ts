import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSwitchingPlanComponent } from './view-switching-plan.component';

describe('ViewSwitchingPlanComponent', () => {
  let component: ViewSwitchingPlanComponent;
  let fixture: ComponentFixture<ViewSwitchingPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSwitchingPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSwitchingPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
