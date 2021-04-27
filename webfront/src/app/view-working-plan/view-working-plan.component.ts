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
    this.dataSource = [{
      'id' : 1,
      'startDate': '1.1.2021.',
      'phoneNumber': '123',
      'status': 'Draft',
      'address': 'Danila K'
    },

    {
      'id' : 2,
      'startDate': '7.5.2021.',
      'phoneNumber': '+456',
      'status': 'Submitted',
      'address': 'Brace R'
    }];
  }


  ngOnInit(): void {
  }

}
