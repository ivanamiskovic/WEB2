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
  totalSize = 0;
  mine = false;
  sort = "ASC"

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  allClick() {
    this.mine = false;
    this.fetch();
  }

  mineClick() {
    this.mine = true;
    this.fetch();
  }

  onNew(): void {
    this.router.navigateByUrl('/add-incidents');
  }

  edit(id: number): void {
    this.router.navigateByUrl('/add-incidents?id=' + id);
  }

  
  public handlePage(e: any) {
    this.page = e.pageIndex;
    this.perPage = e.pageSize;
    this.fetch();
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
      search: this.search,
      mine: this.mine,
      sort: this.sort
    }).subscribe((response: any) => {
      console.log(response);
      this.totalSize = response.total;
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

