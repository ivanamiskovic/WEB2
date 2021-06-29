import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-add-work-request',
  templateUrl: './add-work-request.component.html',
  styleUrls: ['./add-work-request.component.scss']
})
export class AddWorkRequestComponent implements OnInit {

  form: FormGroup;
  public addIncidentInvalid = false;
  public state = 'BASIC';
  data: any;
  dataSourceDevice: any;
  displayedColumnsDevice: string[] = ['name', 'address', 'type', 'lat', 'lng'];
  dataSourceCalls: any;
  displayedColumnsCalls: string[] = ['comment', 'breakdownName', 'reason', 'breakdownPriority'];
  dataSourceCrews: any;
  displayedColumnsCrews: string[] = ['name'];
  dataSourceIncidents: any;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {
    this.form = this.fb.group({
      type: ['', Validators.required],
      note: ['', Validators.required],
      pickerStart: ['', Validators.required],
      pickerEnd: ['', Validators.required],
      urgent: ['', Validators.required],
      cause: ['', Validators.required],
      company: ['', Validators.required],
      address: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      status: ['', Validators.required],
      incident: [''],
      purpose: [''],
    });
  }

  onNewCrew(): void {
    this.router.navigateByUrl('/add-crew');
  }

  onNewCall(): void {
    this.router.navigateByUrl('/add-call');
  }


  fetchCalls(): void {
    this.api.getCalls({}).subscribe((response: any) => {
      this.dataSourceCalls = response;
    });
  }

  onNewDevice(): void {
    this.router.navigateByUrl('/add-device');
  }

  linkClass(): string {
    return this.data && this.data.id ? '' : 'disabled';
  }

  selectNavigation(state: any): void {
    this.state = state;
  }

  fetchDevices(): void {
    this.api.getDevices({}).subscribe(response => {
      console.log(response);
      this.dataSourceDevice = response;
    });
  }

  fetchCrews(): void {
    this.api.getCrews({}).subscribe(response => {
      console.log(response);
      this.dataSourceCrews = response;
    });
  }

  fetchIncidents(): void {
    this.api.getIncidents({
      page: 0,
      perPage: 500,
      search: ''
    }).subscribe(response => {
      console.log(response);
      this.dataSourceIncidents = response;
    });
  }

  ngOnInit(): void {

    this.route.queryParams.subscribe(params => {
      console.log();
      if(params['id']) {
        this.api.getIncident(params['id']).subscribe((response: any) => {
          this.data = response;
          this.form.controls['type'].setValue(this.data.type);
          this.form.controls['note'].setValue(this.data.note);
          this.form.controls['pickerStart'].setValue(this.data.start);
          this.form.controls['pickerEnd'].setValue(this.data.end);
          this.form.controls['company'].setValue(this.data.company);
          this.form.controls['address'].setValue(this.data.address);
          this.form.controls['urgent'].setValue(this.data.urgent);
          this.form.controls['phoneNumber'].setValue(this.data.phoneNumber);
          this.form.controls['cause'].setValue(this.data.cause);
          this.form.controls['status'].setValue(this.data.status);
          this.form.controls['incident'].setValue(this.data.incident);
          this.form.controls['purpose'].setValue(this.data.purpose);
          this.form.controls['created'].setValue(this.data.created);
          this.form.controls['createdBy'].setValue(this.data.createdBy);
        });
      }
    });

    this.fetchDevices();
    this.fetchCalls();
    this.fetchCrews();
    this.fetchIncidents();
  }

  onSubmit(): void {
    this.api.addWorkRequests({
      type: this.form.get('type')?.value,
      note: this.form.get('description')?.value,
      urgent: Boolean(this.form.get('urgent')?.value),
      start: this.form.get('pickerStart')?.value,
      end: this.form.get('pickerEnd')?.value,
      company: this.form.get('company')?.value,
      phoneNumber: this.form.get('phoneNumber')?.value,
      address: this.form.get('address')?.value,
      caause: this.form.get('cause')?.value,
      status: this.form.get('status')?.value, 
      incident: this.form.get('incident')?.value,
      purpose: this.form.get('purpose')?.value,
      created: this.form.get('created')?.value,
      createdBy: this.form.get('createdBy')?.value,
    }).subscribe((response: any) => {
      this.data = response;
    });
  }
}

