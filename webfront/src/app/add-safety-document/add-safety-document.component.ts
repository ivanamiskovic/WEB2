import { Placeholder } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-safety-document',
  templateUrl: './add-safety-document.component.html',
  styleUrls: ['./add-safety-document.component.scss']
})
export class AddSafetyDocumentComponent implements OnInit {

  form: FormGroup;
  public addSafetyDocumentInvalid = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
  ) 
  {
    this.form = this.fb.group({
      type: ['', Validators.required],
      status: ['', Validators.required],
      document_type: ['', Validators.required],
      dateTimeCreated: ['', Validators.required],
      details: ['', Validators.required],
      notes: ['', Validators.required],
      phoneNumber: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  async onSubmit(): Promise<void> {

  }

}
