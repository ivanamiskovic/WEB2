import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-workrequest',
  templateUrl: './view-workrequest.component.html',
  styleUrls: ['./view-workrequest.component.scss']
})
export class ViewWorkrequestComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['type', 'status', 'address', 'start', 'end', 'note', 'id'];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-work-requests');
  }

  edit(id: number): void {
    this.router.navigateByUrl('/add-work-requests?id=' + id);
  }

  delete(id: number): void {
    this.api.deleteWorkRequest(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getWorkRequests().subscribe((response: any) => {
      this.dataSource = response ? response.entities : [];
    });
  }

  onSearchChange(searhcValue: any): void {
    console.log(searhcValue);
  }

  ngOnInit(): void {
    this.fetch();
  }
}
