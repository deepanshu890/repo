import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IUser } from 'src/app/models/user';
import { ITeam } from 'src/app/models/team';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  readonly apiUrl = 'https://localhost:44336/api/Users/';
  readonly apiUrl1 = 'https://localhost:44336/api/Team/';
  public subject = new BehaviorSubject<number>(501);

  constructor(private http:HttpClient) { }

  sendTeamId(teamId : number){
    console.log("Subject send in service")
    this.subject.next(teamId);
    
  }

  receiveTeamId():Observable<number>{  
    console.log("Subject received from service")
    return this.subject.asObservable();
  }

  getEmployeeList():Observable<IUser[]>{
    return this.http.get<IUser[]>(this.apiUrl+'GetAllUsers');
  }

  addUser(firstName: string,lastName:string, emailId: string,mobile:string,city:string,gender:string,address:string,state:string,pin:number): Observable<boolean> {
    var cartObj: IUser;
    
    var y: number = +pin;
    cartObj = {userId:0,addressId:0, firstName: firstName,lastName:lastName, emailId: emailId,phoneNumber:mobile,city:city,gender:gender,addressLine:address,state:state,pincode:y};
    return this.http.post<boolean>(this.apiUrl+'AddUser', cartObj);
  }

  updateUser(userId:number,addressId : number,firstName: string,lastName:string, emailId: string,mobile:string,city:string,gender:string,address:string,state:string,pin:number): Observable<boolean> {
    var cartObj: IUser;
    var x : number = +userId;
    var z : number = +addressId
    var y: number = +pin;
    cartObj = {userId:x,addressId:z, firstName: firstName,lastName:lastName, emailId: emailId,phoneNumber:mobile,city:city,gender:gender,addressLine:address,state:state,pincode:y};
    return this.http.put<boolean>(this.apiUrl+'UpdateUserDetails', cartObj);
  }

  deleteUser(userId: number, addressId: number): Observable<boolean> {
    var cartObj: IUser;
    cartObj = { userId:userId,addressId:addressId, firstName:"",lastName:"", emailId:"",phoneNumber:"",city:"",gender:"",addressLine:"",state:"",pincode:0 };
    let httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }), body: cartObj };
    return this.http.delete<boolean>(this.apiUrl+'DeleteUser', httpOptions);
  }

  getTeamList():Observable<ITeam[]>{
    console.log("abc")
    return this.http.get<ITeam[]>(this.apiUrl1+'GetAllTeams');
  }

  addTeam(teamName: string,projectName:string, year:number,members:number,isActive:number): Observable<boolean> {
    var cartObj: ITeam;   
    var y: number = +year;    var x: number = +members;
    var b : boolean;
    if(isActive == 1) b = true;
    else b = false; 
    cartObj = {teamId:0,teamName:teamName,projectName:projectName,year:y,members:x,isActive:b};
    return this.http.post<boolean>(this.apiUrl1+'AddTeam', cartObj);
  }

  deleteTeam(teamId: number): Observable<boolean> {
    var cartObj: ITeam;
    cartObj = {teamId:teamId,teamName:"",projectName:"",year:0,members:0,isActive:true};
    let httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }), body: cartObj };
    return this.http.delete<boolean>(this.apiUrl1+'DeleteTeam', httpOptions);
  }

  getTeamMembers(teamId:number):Observable<IUser[]>{
    // var cartObj: ITeam;
    // cartObj = {teamId:teamId,teamName:"",projectName:"",year:0,members:0,isActive:true};
    return this.http.get<IUser[]>(this.apiUrl1+'GetTeamMembers'+teamId);
  }
  
}
