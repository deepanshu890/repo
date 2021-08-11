import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  readonly apiUrl = 'https://localhost:44329/api';

  constructor(private http:HttpClient) { }

  getEmployeeList():Observable<any[]>{
    return this.http.get<any>(this.apiUrl+'/HumanResource/getUserDetails');
  }
}
