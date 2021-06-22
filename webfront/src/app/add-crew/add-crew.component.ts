import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-add-crew',
  templateUrl: './add-crew.component.html',
  styleUrls: ['./add-crew.component.scss']
})
export class AddCrewComponent implements OnInit {

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
      name: ['', Validators.required],
    });
    }


  async ngOnInit(): Promise<void>{
  }

  async onSubmit(): Promise<void> {
    this.addCrewInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const name = this.form.get('name')?.value;

        this.api.addCrew({
          name: name
        }).subscribe(response => {
          this.router.navigateByUrl('/dashboard');
        });

      } catch (err) {
        this.addCrewInvalid = true;
      }
  }  else {
      this.formSubmitAttempt = true;
    }
  }
}
