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
    this.api.getWorkingPlans().subscribe((response: any) => {
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
