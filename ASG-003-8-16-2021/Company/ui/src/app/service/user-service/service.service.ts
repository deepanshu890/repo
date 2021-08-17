import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  readonly apiUrl = 'https://localhost:44336/api/Users/';

  constructor(private http:HttpClient) { }

  getEmployeeList():Observable<IUser[]>{
    console.log("abc")
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

  deleteCartProduct(userId: number, addressId: number): Observable<boolean> {
    var cartObj: IUser;
    cartObj = { userId:userId,addressId:addressId, firstName:"",lastName:"", emailId:"",phoneNumber:"",city:"",gender:"",addressLine:"",state:"",pincode:0 };
    let httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }), body: cartObj };
    return this.http.delete<boolean>(this.apiUrl+'DeleteUser', httpOptions);
  }
}
