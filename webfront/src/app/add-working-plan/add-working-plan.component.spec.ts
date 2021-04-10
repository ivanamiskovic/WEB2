import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddWorkingPlanComponent } from './add-working-plan.component';

describe('AddWorkingPlanComponent', () => {
  let component: AddWorkingPlanComponent;
  let fixture: ComponentFixture<AddWorkingPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddWorkingPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddWorkingPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
