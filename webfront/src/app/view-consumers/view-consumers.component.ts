import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-consumers',
  templateUrl: './view-consumers.component.html',
  styleUrls: ['./view-consumers.component.scss']
})
export class ViewConsumersComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['name', 'lastName', 'type', 'location', 'priority', 'phoneNumber', 'id'];

  page = 0;
  perPage = 5;
  search = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-consumer');
  }

  delete(id: number): void {
    this.api.deleteConsumer(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getConsumers({
      page: this.page,
      perPage: this.perPage,
      search: this.search
    }).subscribe((response: any) => {
      console.log(response);
      this.dataSource = response.entities;
    });
  }

  onSearchChange(searhcValue: any): void {
    this.fetch();
  }

  ngOnInit(): void {
    this.fetch();
  }

}







