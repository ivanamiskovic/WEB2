import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  form: FormGroup;
  public addCrewInvalid = false;
  private formSubmitAttempt = false;
  private returnUrl: string;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService)

  { this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    this.form = this.fb.group({
      password: ['', Validators.required],
    });
  }


  async ngOnInit(): Promise<void>{
  }

  async onSubmit(): Promise<void> {
    this.addCrewInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const password = this.form.get('password')?.value;

        this.api.changePassword({
          password: password
        }).subscribe(response => {
          localStorage.clear();
          this.router.navigateByUrl('/login');
        });

      } catch (err) {
        this.addCrewInvalid = true;
      }
    }  else {
      this.formSubmitAttempt = true;
    }
  }
}
