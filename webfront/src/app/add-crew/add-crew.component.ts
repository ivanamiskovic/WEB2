import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-crew',
  templateUrl: './add-crew.component.html',
  styleUrls: ['./add-crew.component.scss']
})
export class AddCrewComponent implements OnInit {

  form: FormGroup;
  public registrationInvalid = false;
  private formSubmitAttempt = false;
  private returnUrl: string;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,) { this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    this.form = this.fb.group({
      name: ['', Validators.email],
      id: ['', Validators.required],
    });
    }


  async ngOnInit(): Promise<void>{
  }

  async onSubmit(): Promise<void> {
    
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const name = this.form.get('name')?.value;
        const id = this.form.get('id')?.value;
      } catch (err) {
        this.formSubmitAttempt = true;
      }
  }
  
  }
}
