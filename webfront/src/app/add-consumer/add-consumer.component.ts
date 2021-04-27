import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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






  onSubmit() {}

  ngOnInit(): void {
  }

}





