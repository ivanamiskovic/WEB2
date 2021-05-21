import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-add-switching-plan',
  templateUrl: './add-switching-plan.component.html',
  styleUrls: ['./add-switching-plan.component.scss']
})
export class AddSwitchingPlanComponent implements OnInit {

  form: FormGroup;
  public addSwitchingPlanInvalid = false;
  instructions: any

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
      typeOfWork: ['', Validators.required],     
      createdBy: ['', Validators.required],
      purpose: ['', Validators.required],
      details: ['', Validators.required],
      notes: ['', Validators.required],
      company: ['', Validators.required],
      phone: ['', Validators.required],
    });

    this.instructions = [
    ]
  }

  ngOnInit(): void {
  }

  async onSubmit(): Promise<void> {
    console.log(this.form.value)

    this.instructions.push({
      id: this.instructions.length + 1,
      name: this.form.value.name

     
    });
   this.api.addSwitchingPlan({
      type: this.form.get('type')?.value,
      status: this.form.get('status')?.value,
      typeOfWork: this.form.get('typeOfWork')?.value,
      createdBy: this.form.get('createdBy')?.value,
      purpose: this.form.get('purpose')?.value,
      details: this.form.get('details')?.value,
      notes: this.form.get('notes')?.value,
      company: this.form.get('company')?.value,
      phone: this.form.get('phone')?.value
    }).subscribe((response: any) => {
      console.log(response);
    });

  }

  public onDelete(id:any) {

    let itemTodelete = null;

    for(let item of this.instructions) {
      if(item.id == id) {
        itemTodelete = item;
      }
    }

    if(itemTodelete == null) {
      return;
    }

    let index = this.instructions.indexOf(itemTodelete);

    if(index > -1) {
      this.instructions.splice(index, 1);
    }

  } 
  

}
