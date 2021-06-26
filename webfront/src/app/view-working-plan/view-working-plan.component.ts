import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-working-plan',
  templateUrl: './view-working-plan.component.html',
  styleUrls: ['./view-working-plan.component.scss']
})
export class ViewWorkingPlanComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['street', 'starOfWork', 'endOfWork', 'notes', 'company', 'number', 'id'];

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
    this.router.navigateByUrl('/add-working-plan');
  }

  edit(id: number): void {
    this.router.navigateByUrl('/add-working-plan?id=' + id);
  }

  delete(id: number): void {
    this.api.deleteWorkingPlan(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getWorkingPlans({
      page: this.page,
      perPage: this.perPage,
      search: this.search
    }).subscribe((response : any) => {
      console.log(response);
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
