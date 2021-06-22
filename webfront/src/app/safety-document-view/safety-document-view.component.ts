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
    this.dataSource = [
      {
        'id' : 1,
        'startDate': '1.1.2021.',
        'phoneNumber': '08956',
        'status': 'dkjfg',
        'address': 'adresa sokdo'
      },

      {
        'id' : 2,
        'startDate': '7.5.2021.',
        'phoneNumber': '+38123476',
        'status': 'omg',
        'address': 'adresa sdfyrfbhbv'
      },

      {
        'id' : 3,
        'startDate': '12.12.2021.',
        'phoneNumber': '+385679476',
        'status': 'wtf',
        'address': 'adresa trafsdvh'
      }

    ];
  }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }
  
  ngOnInit(): void {
  }

}
