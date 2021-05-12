import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private REST_API_SERVER = "https://localhost:44382";

  constructor(private httpClient: HttpClient) { }

  public login(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/token', data);
  }

  public registration(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data)
  }
}
