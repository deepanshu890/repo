import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDetails } from '../models/userDetails';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IUpdateEmployee } from '../models/IUpdateEmployee';


@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  readonly apiUrl = 'https://localhost:44329/api';

  constructor(private http:HttpClient) { }

  getEmployeeList():Observable<UserDetails[]>{
    return this.http.get<UserDetails[]>(this.apiUrl+'/HumanResource/getUserDetails');
  }

  updateEmployee(employee : IUpdateEmployee):Observable<IUpdateEmployee>{
    //const https = {header:new HttpHeaders({'Content-Type':'application/json'})}
    return this.http.put<IUpdateEmployee>(this.apiUrl+'/Person/UpdateEmployee',employee);
  }

}
