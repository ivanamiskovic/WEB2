import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-consumers',
  templateUrl: './view-consumers.component.html',
  styleUrls: ['./view-consumers.component.scss']
})
export class ViewConsumersComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['name', 'lastname', 'location', 'priority', 'phonenumber','id','type'];
  constructor() { }

  ngOnInit(): void {
  }

}







