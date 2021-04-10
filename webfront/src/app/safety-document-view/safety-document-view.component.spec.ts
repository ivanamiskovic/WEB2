import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SafetyDocumentViewComponent } from './safety-document-view.component';

describe('SafetyDocumentViewComponent', () => {
  let component: SafetyDocumentViewComponent;
  let fixture: ComponentFixture<SafetyDocumentViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SafetyDocumentViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SafetyDocumentViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
