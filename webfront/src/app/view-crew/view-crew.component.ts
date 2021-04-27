import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-crew',
  templateUrl: './view-crew.component.html',
  styleUrls: ['./view-crew.component.scss']
})
export class ViewCrewComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['name', 'id'];

  constructor() {
    this.dataSource = [
      {
        'id' : 1,
        'name': 'Sara'
      },
      {
        'id' : 2,
        'name': 'Ivana'
      }

    ];
   }

  ngOnInit(): void {
  }

}
