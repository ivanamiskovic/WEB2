import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-switching-plan',
  templateUrl: './view-switching-plan.component.html',
  styleUrls: ['./view-switching-plan.component.scss']
})
export class ViewSwitchingPlanComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['street', 'startOfWork', 'endOfWork', 'notes', 'company','number','createDocument','point','userCreate','team'];

  page = 0;
  perPage = 5;
  search = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {this.dataSource = []; }

  onSearchChange(searhcValue: any): void {
    this.fetch();
  }

  ngOnInit(): void {
  }

  onNew() {
    this.router.navigateByUrl('/add-switchinng-plan');
  }

  fetch(): void {
    this.api.getSwitchingPlans({
      page: this.page,
      perPage: this.perPage,
      search: this.search
    }).subscribe((response : any) => {
      console.log(response);
      this.dataSource = response.entities;
    });
  }

}
