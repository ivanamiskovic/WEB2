import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-incidents-view',
  templateUrl: './incidents-view.component.html',
  styleUrls: ['./incidents-view.component.scss']
})
export class IncidentsViewComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['description', 'eta', 'etr', 'ata', 'calls', 'affectedCustomers', 'id'];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-incidents');
  }

  edit(id: number): void {
    this.router.navigateByUrl('/add-incidents?id=' + id);
  }

  delete(id: number): void {
    this.api.deleteIncident(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getIncidents().subscribe((response: any) => {
      this.dataSource = response ? response.entities : [];
    });
  }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }

  ngOnInit(): void {
    this.fetch();
  }
}

