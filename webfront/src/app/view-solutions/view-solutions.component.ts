import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-solutions',
  templateUrl: './view-solutions.component.html',
  styleUrls: ['./view-solutions.component.scss']
})
export class ViewSolutionsComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['cause', 'subCase', 'material'];

  page = 0;
  perPage = 5;
  search = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService) 
    {this.dataSource = []; }

    onSearchChange(searhcValue: any): void {
      this.fetch();
    }
  
    ngOnInit(): void {
    }
  
    onNew() {
      this.router.navigateByUrl('/add-solution');
    }
  
    fetch(): void {
      this.api.getSolutions({
        page: this.page,
        perPage: this.perPage,
        search: this.search
      }).subscribe((response : any) => {
        console.log(response);
        this.dataSource = response.entities;
      });
    }

}
