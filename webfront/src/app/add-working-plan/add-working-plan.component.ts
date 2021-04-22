import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {ThemePalette} from '@angular/material/core';


@Component({
  selector: 'app-add-working-plan',
  templateUrl: './add-working-plan.component.html',
  styleUrls: ['./add-working-plan.component.scss']
})
export class AddWorkingPlanComponent implements OnInit {

  form: FormGroup;
  public addWorkingPlanInvalid = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    this.form = this.fb.group({
      type: ['', Validators.required],
      status: ['', Validators.required],
      typeOfWork: ['', Validators.required],
      createdBy: ['', Validators.required],
      purpose: ['', Validators.required],
      details: ['', Validators.required],
      notes : ['', Validators.required],
      urgent: ['', Validators.required],
      company: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required]
    });

    this.form.controls['status'].disable();
    this.form.controls['createdBy'].disable();
   }

  ngOnInit(): void {
    
  }

  async onSubmit(): Promise<void> {

  }

}
