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
  


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  onNew(): void {
    this.router.navigateByUrl('/add-device');
  }

  delete(id: number): void {
    this.api.deleteDevice(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    
    this.api.getDevices().subscribe(response => {
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
