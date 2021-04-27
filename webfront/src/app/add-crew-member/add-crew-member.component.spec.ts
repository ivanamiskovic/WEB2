import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCrewMemberComponent } from './add-crew-member.component';

describe('AddCrewMemberComponent', () => {
  let component: AddCrewMemberComponent;
  let fixture: ComponentFixture<AddCrewMemberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCrewMemberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCrewMemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
