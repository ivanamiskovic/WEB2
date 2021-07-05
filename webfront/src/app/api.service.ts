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
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data);
  }

  public editUser(data: any) {
    return this.httpClient.put(this.REST_API_SERVER + '/api/users', data);
  }

   public addCrew(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/crews', data); //
  }
  public addCrewMember(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/crewMembers', data); 
  }

  public getCrews(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/crews?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&sort=' + data.sort);
  }

  public getCrewMembers(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/crewMembers?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search);
  }

  public getSafetyDocument(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/crews?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&mine=' + data.mine + "&sort=" + data.sort);
  }
  public deleteCrew(id: any) {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/crews/' + id);
  }

  public getCurrentUser() {
    return this.httpClient.get(this.REST_API_SERVER + '/api/users/current'); //
  }
  /*  public viewWorkingPlan(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data);
  }

   public viewCrew(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/users', data);
  }  */
  public addSwitchingPlan(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/switchingPlans', data);
  }
  public addSafetyDocument(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/safetyDocuments', data);
  }
  public addCosumerComponent(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/consumers', data);
  }

  public getConsumers(data : any) : any {
    return this.httpClient.get(this.REST_API_SERVER + '/api/consumers?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&sort=' + data.sort);
  }

  public deleteConsumer(id: any) {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/consumers/' + id);
  }

  public getUsersForVerify() {
    return this.httpClient.get(this.REST_API_SERVER + '/api/users/verification');
  }

  public userVerify(id: any) {
    return this.httpClient.put(this.REST_API_SERVER + '/api/users/verification/' + id, {});
  }

  public addDevice(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/devices', data);
  }

  public getUsers(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/users?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search);
  }

  public getDevices(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/devices?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&sort=' + data.sort);
  }

  public deleteDevice(id: any) {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/devices/' + id);
  }

  public deleteIncident(id: any) {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/incidents/' + id);
  }

  public getIncidents(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/incidents?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + "&mine=" + data.mine + "&sort=" + data.sort);
  }

  public getIncident(id: any): any {
    return this.httpClient.get(this.REST_API_SERVER + '/api/incidents/' + id);
  }

  public getDocumentHistories(data:any){
    return this.httpClient.get(this.REST_API_SERVER + '/api/documentHistory?workRequestId=' + data.workRequestId);
  }
  public getDocumentHistory(id: any): any {
    return this.httpClient.get(this.REST_API_SERVER + '/api/documentHistory/' + id);
  }

  public addIncident(data: any): any {
    return this.httpClient.post(this.REST_API_SERVER + '/api/incidents', data);
  }

  public addCall(data: any): any {
    return this.httpClient.post(this.REST_API_SERVER + '/api/calls', data);
  }

  public getCalls(data: any): any {
    return this.httpClient.get(this.REST_API_SERVER + '/api/calls?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + "&sort=" + data.sort);
  }

  public deleteCall(id: any): any {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/calls/' + id);
  }

  public changePassword(data: any) {
    return this.httpClient.put(this.REST_API_SERVER + '/api/users/change-password', data);
  }

  public deleteWorkRequest(id: any) {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/work-requests/' + id);
  }

  public getWorkRequests(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/work-requests?page=' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&mine=' + data.mine + "&sort=" + data.sort);
  }

  public addWorkRequests(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/work-requests/', data);
  }

  public deleteWorkingPlan(id: any) {
    return this.httpClient.delete(this.REST_API_SERVER + '/api/workingPlan/' + id);
  }

  public getWorkingPlans(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/workingPlan?page=/' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&mine=' + data.mine + '&sort=' + data.sort);
  }

  public addWorkingPlan(data: any) {
    return this.httpClient.post(this.REST_API_SERVER + '/api/workingPlan/', data);
  }

  public getSwitchingPlans(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/switching-plans?page=/' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search + '&mine=' + data.mine + '&sort=' + data.sort);
  }

  public getSolutions(data: any) {
    return this.httpClient.get(this.REST_API_SERVER + '/api/switching-plans?page=/' + data.page 
    + '&perPage=' + data.perPage + '&search=' + data.search);
  }

  public setOperator(id: any) {
    return this.httpClient.put(this.REST_API_SERVER + '/api/incidents/operater/' + id, {});
  }
}
