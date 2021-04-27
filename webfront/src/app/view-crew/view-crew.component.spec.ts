import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCrewComponent } from './view-crew.component';

describe('ViewCrewComponent', () => {
  let component: ViewCrewComponent;
  let fixture: ComponentFixture<ViewCrewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewCrewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCrewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
