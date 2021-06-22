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
      lastName: ['', Validators.required],
      location: ['', Validators.required],
      priority: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      type: ['', Validators.required],
    });

  }

  onSubmit() {
  this.api.addCosumerComponent({
      name: this.form.get('name')?.value,
      location: this.form.get('location')?.value,
      priority: this.form.get('priority')?.value,
    lastName: this.form.get('lastName')?.value,
      phoneNumber: this.form.get('phoneNumber')?.value,
      type: this.form.get('type')?.value
    }).subscribe(response => {
      this.router.navigateByUrl('/dashboard');
    });


  }

  ngOnInit(): void {
  }

}





