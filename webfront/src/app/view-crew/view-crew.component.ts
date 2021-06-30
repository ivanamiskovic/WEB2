import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-crew',
  templateUrl: './view-crew.component.html',
  styleUrls: ['./view-crew.component.scss']
})
export class ViewCrewComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['name', 'id'];

  page = 0;
  perPage = 5;
  search = '';
  totalSize = 0;
  sort = "ASC"

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-crew');
  }

  public handlePage(e: any) {
    this.page = e.pageIndex;
    this.perPage = e.pageSize;
    this.fetch();
  }

  delete(id: number): void {
    this.api.deleteCrew(id).subscribe((response: any) => {
      this.fetch();
    });
  }

  fetch(): void {

    this.api.getCrews({
      page: this.page,
      perPage: this.perPage,
      search: this.search,
      sort: this.sort
    }).subscribe((response : any) => {
      console.log(response);
      this.totalSize = response.total;
      this.dataSource = response.entities;
    });
  }

  onSearchChange(searhcValue: any): void {
    this.fetch();
  }

  ngOnInit(): void {
    this.fetch();
  }

}
