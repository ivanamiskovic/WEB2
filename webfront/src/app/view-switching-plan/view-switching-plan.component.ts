import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-view-switching-plan',
  templateUrl: './view-switching-plan.component.html',
  styleUrls: ['./view-switching-plan.component.scss']
})
export class ViewSwitchingPlanComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['street', 'startOfWork', 'endOfWork', 'notes', 'company','number','createDocument','point','userCreate','team'];

  constructor(private router: Router) {this.dataSource = []; }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }

  ngOnInit(): void {
  }

  onNew() {
    this.router.navigateByUrl('/add-switchinng-plan');
  }

}
