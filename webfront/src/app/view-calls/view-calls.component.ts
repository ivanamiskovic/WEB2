import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-calls',
  templateUrl: './view-calls.component.html',
  styleUrls: ['./view-calls.component.scss']
})
export class ViewCallsComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['comment', 'breakdownName', 'reason', 'breakdownPriority', 'id'];

  page = 0;
  perPage = 5;
  search = '';
  totalSize = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-call');
  }

  public handlePage(e: any) {
    this.page = e.pageIndex;
    this.perPage = e.pageSize;
    this.fetch();
  }

  delete(id: number): void {
    this.api.deleteCall(id).subscribe((response: any) => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getCalls({
      page: this.page,
      perPage: this.perPage,
      search: this.search
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
