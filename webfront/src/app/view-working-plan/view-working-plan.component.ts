import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-working-plan',
  templateUrl: './view-working-plan.component.html',
  styleUrls: ['./view-working-plan.component.scss']
})
export class ViewWorkingPlanComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['id', 'startDate', 'phoneNumber', 'status', 'address'];
  
  constructor()
  { 
    this.dataSource = [];
  }


  ngOnInit(): void {
  }

}
