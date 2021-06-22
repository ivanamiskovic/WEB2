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
    this.api.getConsumers().subscribe((response: any) => {
      this.dataSource = response.entities;
    });
  }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }

  ngOnInit(): void {
    this.fetch();
  }

}







