import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewConsumersComponent } from './view-consumers.component';

describe('ViewConsumersComponent', () => {
  let component: ViewConsumersComponent;
  let fixture: ComponentFixture<ViewConsumersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewConsumersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewConsumersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
