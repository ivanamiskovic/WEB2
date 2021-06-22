import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-calls',
  templateUrl: './view-calls.component.html',
  styleUrls: ['./view-calls.component.scss']
})
export class ViewCallsComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['comment', 'breakdownName', 'reason', 'breakdownPriority', 'id'];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-call');
  }

  delete(id: number): void {
    this.api.deleteCall(id).subscribe((response: any) => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getCalls().subscribe((response: any) => {
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
