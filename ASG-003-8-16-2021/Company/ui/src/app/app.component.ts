import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  invalidLogin : boolean = false;
  //user:string;
  constructor(private router: Router){}

  ngOnInit(): void {
    var user = localStorage.getItem("JWT");
    console.log(user)
    if(user)  this.invalidLogin = true;
    console.log("login status : " + this.invalidLogin)
    
  }

  logOut(){
    localStorage.removeItem("JWT");
    window.location.reload();
  }



  
}
