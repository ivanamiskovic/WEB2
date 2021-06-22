import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.scss']
})
export class AddDeviceComponent implements OnInit {
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
      name: ['', Validators.required],
      address: ['', Validators.required],
      type: ['', Validators.required],
      lat: ['', Validators.required],
      lng: ['', Validators.required]
    });

  }

  onSubmit() {
    this.api.addDevice({
      name: this.form.get('name')?.value,
      type: this.form.get('type')?.value,
      address: this.form.get('address')?.value,
      lat: Number(this.form.get('lat')?.value),
      lng: Number(this.form.get('lng')?.value),
    }).subscribe(response => {
      this.router.navigateByUrl('/dashboard');
    });


  }

  ngOnInit(): void {
  }

}

