import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-view-devices',
  templateUrl: './view-devices.component.html',
  styleUrls: ['./view-devices.component.scss']
})
export class ViewDevicesComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['name', 'address', 'type', 'lat', 'lng', 'id'];
  


  page = 0;
  perPage = 5;
  search = '';
  totalSize = 0;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-device');
  }

  public handlePage(e: any) {
    this.page = e.pageIndex;
    this.perPage = e.pageSize;
    this.fetch();
  }
  delete(id: number): void {
    this.api.deleteDevice(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {

    this.api.getDevices({
      page: this.page,
      perPage: this.perPage,
      search: this.search
    }).subscribe((response : any) => {
      console.log(response);
      this.totalSize = response.total;
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
