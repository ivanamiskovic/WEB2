import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-incident',
  templateUrl: './add-incident.component.html',
  styleUrls: ['./add-incident.component.scss']
})
export class AddIncidentComponent implements OnInit {

  form: FormGroup;
  public addIncidentInvalid = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {
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

  onSubmit() {} 
}
