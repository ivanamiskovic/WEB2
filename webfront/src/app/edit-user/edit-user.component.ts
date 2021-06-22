import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss']
})
export class EditUserComponent implements OnInit {

  form: FormGroup;
  public registrationInvalid = false;
  private formSubmitAttempt = false;
  private returnUrl: string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    let userString  = '';
    userString = localStorage.getItem('user') as any;
    let user = null;
    user = JSON.parse(userString);
    this.form = this.fb.group({
      email: [user.email, Validators.email],
      firstName: [user.name, Validators.required],
      lastName: [user.lastName, Validators.required],
      address: [user.address, Validators.required],
      userType: [user.userType, Validators.required],
    });
  }

  async ngOnInit(): Promise<void> {

  }

  async onSubmit(): Promise<void> {
    this.registrationInvalid = false;
    this.formSubmitAttempt = false;
    try {

      this.api.editUser({
        email: this.form.get('email')?.value,
        name: this.form.get('firstName')?.value,
        lastName: this.form.get('lastName')?.value,
        address: this.form.get('address')?.value,
        userType: Number(this.form.get('userType')?.value)
      }).subscribe(response => {
        this.router.navigateByUrl('/dashboard');
      });

    } catch (err) {
      this.registrationInvalid = true;
    }
  }
}
