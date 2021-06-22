import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

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

    this.form = this.fb.group({
      email: ['', Validators.email],
      password: ['', Validators.required],
      passwordConfirm: ['', Validators.required],
      username: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      address: ['', Validators.required],
      userType: ['', Validators.required],
    });
  }

  async ngOnInit(): Promise<void> {

  }

  async onSubmit(): Promise<void> {
    this.registrationInvalid = false;
    this.formSubmitAttempt = false;
    // if (this.form.valid) {
      try {

        this.api.registration({
          username: this.form.get('username')?.value,
          email: this.form.get('email')?.value,
          name: this.form.get('firstName')?.value,
          lastName: this.form.get('lastName')?.value,
          password: this.form.get('password')?.value,
          passwordConfirm: this.form.get('passwordConfirm')?.value,
          address: this.form.get('address')?.value,
          userType: Number(this.form.get('userType')?.value)
        }).subscribe(response => {
          this.router.navigateByUrl('/login');
        });

      } catch (err) {
        this.registrationInvalid = true;
      }
    // } else {
    //   this.formSubmitAttempt = true;
    // }
  }
}
