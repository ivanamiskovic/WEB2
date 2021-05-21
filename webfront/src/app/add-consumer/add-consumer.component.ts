import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-add-consumer',
  templateUrl: './add-consumer.component.html',
  styleUrls: ['./add-consumer.component.scss']
})
export class AddConsumerComponent implements OnInit {
    form: FormGroup;
    public addConsumerInvalid = false;
    instructions: any
  
    constructor(
      private fb: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
     private api: ApiService
    ) 

  {
    this.form = this.fb.group({
      name: ['', Validators.required],
      lastaname: ['', Validators.required],
      location: ['', Validators.required],     
      priority: ['', Validators.required],
      phonenumber: ['', Validators.required],
      id: ['', Validators.required],
      type: ['', Validators.required],
      
    });

    this.instructions = [
    ]
  }

  onSubmit() {
  this.api.addCosumerComponent({
      name: this.form.get('name')?.value,
      location: this.form.get('location')?.value,
      priority: this.form.get('priority')?.value,
      lastName: this.form.get('lastName')?.value,
      phonenumber: this.form.get('phonenumber')?.value,
      id: this.form.get('id')?.value,
      type: this.form.get('type')?.value
    }).subscribe(response => {
      console.log(response);
    });


  }

  ngOnInit(): void {
  }

}





