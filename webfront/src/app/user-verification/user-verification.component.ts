import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ApiService} from '../api.service';

@Component({
  selector: 'app-user-verification',
  templateUrl: './user-verification.component.html',
  styleUrls: ['./user-verification.component.scss']
})
export class UserVerificationComponent implements OnInit {
  dataSource: any;
  displayedColumns: string[] = ['email', 'id'];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private api: ApiService
  ) {

  }

  verify(id: number): void {
    this.api.userVerify(id).subscribe(response => {
      this.fetch();
    });
  }

  fetch(): void {
    this.api.getUsersForVerify().subscribe(response => {
      console.log(response);
      this.dataSource = response;
    });
  }

  ngOnInit(): void {
    this.fetch();
  }

}
