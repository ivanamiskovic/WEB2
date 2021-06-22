import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewWorkrequestComponent } from './view-workrequest.component';

describe('ViewWorkrequestComponent', () => {
  let component: ViewWorkrequestComponent;
  let fixture: ComponentFixture<ViewWorkrequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewWorkrequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewWorkrequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
