import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-add-call',
  templateUrl: './add-call.component.html',
  styleUrls: ['./add-call.component.scss']
})
export class AddCallComponent implements OnInit {
  form: FormGroup;
  public addConsumerInvalid = false;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  )

  {
    this.form = this.fb.group({
      comment: ['', Validators.required],
      breakdownName: ['', Validators.required],
      reason: ['', Validators.required],
      breakdownPriority: ['', Validators.required],
    });

  }

  onSubmit() {
    this.api.addCall({
      comment: this.form.get('comment')?.value,
      breakdownName: this.form.get('breakdownName')?.value,
      reason: Number(this.form.get('reason')?.value),
      breakdownPriority: Number(this.form.get('breakdownPriority')?.value),
    }).subscribe((response : any) => {
      this.router.navigateByUrl('/dashboard');
    });
  }

  ngOnInit(): void {
  }

}

