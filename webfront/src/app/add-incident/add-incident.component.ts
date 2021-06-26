import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-add-incident',
  templateUrl: './add-incident.component.html',
  styleUrls: ['./add-incident.component.scss']
})
export class AddIncidentComponent implements OnInit {

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

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {
    this.form = this.fb.group({
      type: ['', Validators.required],
      priority: ['', Validators.required],
      confirmed: ['', Validators.required],
      affectedCustomers: ['', Validators.required],
      calls: ['', Validators.required],
      voltage: ['', Validators.required],
      pickerETA: ['', Validators.required],
      pickerATA: ['', Validators.required],
      pickerOutage: ['', Validators.required],
      description: ['', Validators.required],
      pickerETR: ['', Validators.required],
      pickerScheduled: ['', Validators.required],
      cause: ['', Validators.required],
      subcause: ['', Validators.required],
      constructionType: ['', Validators.required],
      material: ['', Validators.required],
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

  ngOnInit(): void {

    this.route.queryParams.subscribe(params => {
      console.log();
      if(params['id']) {
        this.api.getIncident(params['id']).subscribe((response: any) => {
          this.data = response;
          this.form.controls['priority'].setValue(this.data.priority);
          this.form.controls['type'].setValue(this.data.type);
          this.form.controls['description'].setValue(this.data.description);
          this.form.controls['confirmed'].setValue(this.data.confirmed);
          this.form.controls['pickerETA'].setValue(this.data.eta);
          this.form.controls['pickerATA'].setValue(this.data.ata);
          this.form.controls['affectedCustomers'].setValue(this.data.affectedCustomers);
          this.form.controls['calls'].setValue(this.data.calls);
          this.form.controls['pickerOutage'].setValue(this.data.incidentDateAndTime);
          this.form.controls['voltage'].setValue(this.data.voltegeLevel);
          this.form.controls['pickerScheduled'].setValue(this.data.estimatedWorkTime);
          this.form.controls['pickerETR'].setValue(this.data.etr);
        });
      }
    });

    this.fetchDevices();
    this.fetchCalls();
    this.fetchCrews();
  }

  onSubmit(): void {
    this.api.addIncident({
      priority: Number(this.form.get('priority')?.value),
      type: Number(this.form.get('type')?.value),
      description: this.form.get('description')?.value,
      confirmed: Boolean(this.form.get('confirmed')?.value),
      eta: this.form.get('pickerETA')?.value,
      ata: this.form.get('pickerATA')?.value,
      affectedCustomers: Number(this.form.get('affectedCustomers')?.value),
      calls: Number(this.form.get('calls')?.value),
      incidentDateAndTime: this.form.get('pickerOutage')?.value,
      etr: this.form.get('pickerETR')?.value,
      voltegeLevel: Number(this.form.get('voltage')?.value),
      estimatedWorkTime: this.form.get('pickerScheduled')?.value,
    }).subscribe((response: any) => {
      this.data = response;
    });
  }
}
