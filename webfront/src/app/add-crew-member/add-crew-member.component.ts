import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-add-crew-member',
  templateUrl: './add-crew-member.component.html',
  styleUrls: ['./add-crew-member.component.scss']
})
export class AddCrewMemberComponent implements OnInit {

  form: FormGroup;
  public addCrewMemberInvalid = false;
  private formSubmitAttempt = false;
  private returnUrl: string;
  public users: any;
  public crews: any;

  constructor( private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService)

    { this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    this.form = this.fb.group({
      crew: ['', Validators.required],
      user: ['', Validators.required],
    }); }
    

    fetch(): void {
      this.api.getUsers({
        page: 0,
        perPage: 500,
        search: ''
      }).subscribe((response : any) => {
        console.log(response);
        this.users = response.entities;
      });
    }

    fetchCrews(): void {
      this.api.getCrews({
        page: 0,
        perPage: 500,
        search: ''
      }).subscribe((response: any) => {
        console.log(response);
        this.crews = response.entities;
      });
    }

  ngOnInit(): void {
    this.fetch();
    this.fetchCrews();
  }

  onSubmit() {
    const user = this.form.get('user')?.value;
    const crew = this.form.get('crew')?.value;

    this.api.addCrewMember({
      user: { id: parseInt(user) },
      crew: { id: parseInt(crew) }
    }).subscribe(response => {
      this.router.navigateByUrl('/dashboard');
    });
  }
}
