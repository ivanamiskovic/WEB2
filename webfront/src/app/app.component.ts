import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'webfront';
  isUserLogin = false;
  public name = '';

  constructor(private router: Router)
  {
    router.events.subscribe((val) => {
      // see also
      this.checIfUserLogin();
  });
  }

  ngOnInit() {
    this.checIfUserLogin();
  }

  logout() {
    localStorage.clear();
    this.checIfUserLogin();
    this.router.navigateByUrl('/');
  }

  checIfUserLogin() {

    let token = localStorage.getItem('token');

    if(token) {
      this.isUserLogin = true;
    }
    else {
      this.isUserLogin = false;
    }

    let userString = localStorage.getItem('user');
    let user = null
    if(userString != null) {
      user = JSON.parse(userString);
      this.name = user.name + ' ' + user.lastName;
    }

  }
}
