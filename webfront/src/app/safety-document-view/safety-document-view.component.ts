import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-safety-document-view',
  templateUrl: './safety-document-view.component.html',
  styleUrls: ['./safety-document-view.component.scss']
})
export class SafetyDocumentViewComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['id', 'startDate', 'phoneNumber', 'status', 'address'];

  constructor() 
  {
    this.dataSource = [];
  }

  ngOnInit(): void {
  }

}
