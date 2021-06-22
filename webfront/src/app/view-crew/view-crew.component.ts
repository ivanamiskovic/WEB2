import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-crew',
  templateUrl: './view-crew.component.html',
  styleUrls: ['./view-crew.component.scss']
})
export class ViewCrewComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['name', 'id'];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-crew');
  }

  delete(id: number): void {
    this.api.deleteCrew(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getCrews().subscribe(response => {
      console.log(response);
      this.dataSource = response;
    });
  }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }

  ngOnInit(): void {
    this.fetch();
  }

}
