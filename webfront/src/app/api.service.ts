import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private REST_API_SERVER = "https://localhost:44382";
  AddSwitchingPlan: any;
  AddSafetyDocument: any;
  AddCosumerComponent: any;

  constructor(private httpClient: HttpClient) { }

  public login(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/token', data);
  }

  public registration(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data)
  }

  public addSwitchingPlan(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data)
  }
  public addSafetyDocument(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data)
  }
  public addCosumerComponent(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data)
  }


}
