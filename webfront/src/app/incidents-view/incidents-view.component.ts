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

  page = 0;
  perPage = 5;
  search = '';

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
    this.api.getIncidents({
      page: this.page,
      perPage: this.perPage,
      search: this.search
    }).subscribe((response: any) => {
      console.log(response);
      this.dataSource = response.entities;
    });
  }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }

  ngOnInit(): void {
    this.fetch();
  }
}

