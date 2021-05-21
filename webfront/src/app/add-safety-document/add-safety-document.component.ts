import { Placeholder } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

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
  private api: ApiService
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
   this.api.addSafetyDocument({
      type: this.form.get('type')?.value,
      status: this.form.get('status')?.value,
      document_type: this.form.get('document_type')?.value,
      dateTimeCreated: this.form.get('dateTimeCreated')?.value,
      details: this.form.get('details')?.value,
      notes: this.form.get('notes')?.value,
      phoneNumber: this.form.get('phoneNumber')?.value
      
    }).subscribe(response => {
      console.log(response);
    });
    
  }

}
