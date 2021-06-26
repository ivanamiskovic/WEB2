import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-safety-document-view',
  templateUrl: './safety-document-view.component.html',
  styleUrls: ['./safety-document-view.component.scss']
})
export class SafetyDocumentViewComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['id', 'startDate', 'phoneNumber', 'status', 'address'];
  
  page = 0;
  perPage = 5;
  search = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) 
  {
    this.dataSource = []
  }
  fetch(): void {
    
    this.api.getSafetyDocument({
      page: 0,
      perPage: 5,
      search: '',
    }).subscribe((response: any) => {
      
      console.log(response);
   
    
      this.dataSource = response.entities;
    });
  }
  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }
  
  ngOnInit(): void {
  }

}
