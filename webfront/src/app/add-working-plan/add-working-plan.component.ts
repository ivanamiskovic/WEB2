import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {ThemePalette} from '@angular/material/core';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-add-working-plan',
  templateUrl: './add-working-plan.component.html',
  styleUrls: ['./add-working-plan.component.scss']
})
export class AddWorkingPlanComponent implements OnInit {

  form: FormGroup;
  public addWorkingPlanInvalid = false;
  private formSubmitAttempt = false;
  private returnUrl: string;
  instructions: any;
  user:any

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';


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
      address: ['', Validators.required],
      date:['', Validators.required]
    });

    this.form.controls['status'].disable();
    this.form.controls['createdBy'].disable();
    this.form.controls['date'].disable();
   }

  ngOnInit(): void {
    this.api.getCurrentUser().subscribe(response =>{
      console.log(response);
      this.user = response;
    })
  }

  async onSubmit(): Promise<void> {
/**/ 
  this.addWorkingPlanInvalid = false;
  this.formSubmitAttempt = false;
  if (this.form.valid) {
    try {
      const type = this.form.get('type')?.value;
      const status = this.form.get('status')?.value;
      const typeOfWork = this.form.get('typeOfWork')?.value;
      const createdBy = this.form.get('createdBy')?.value;
      const purpose = this.form.get('purpose')?.value;
      const details = this.form.get('details')?.value;
      const notes = this.form.get('notes')?.value;
      const urgent = this.form.get('urgent')?.value;
      const company = this.form.get('company')?.value;
      const phone = this.form.get('phone')?.value;
      const address = this.form.get('address')?.value;
      const date = this.form.get('date')?.value;


      this.api.addWorkingPlan({
        type: type,
        status: status,
        typeOfWork:typeOfWork,
        createdBy: createdBy,
        purpose:purpose,
        details:details,
        notes:notes,
        urgent:urgent,
        company:company,
        phone:phone,
        address:address,
        date:date

      }).subscribe(response => {
        console.log(response);
      });

    } catch (err) {
      this.addWorkingPlanInvalid = true;
    }
  } else {
    this.formSubmitAttempt = true;
  }
}
  }


