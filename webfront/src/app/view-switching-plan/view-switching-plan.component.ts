import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-switching-plan',
  templateUrl: './view-switching-plan.component.html',
  styleUrls: ['./view-switching-plan.component.scss']
})
export class ViewSwitchingPlanComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['street', 'startOfWork', 'endOfWork', 'notes', 'company','number','createDocument','point','userCreate','team'];

  constructor() { }

  ngOnInit(): void {
  }

}
