import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/service/user-service/service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private dialog: MatDialog, private fb: FormBuilder, private service: ServiceService,private router: Router) { }
  addForm = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required],
  });

  ngOnInit(): void {
  }
  invalidLogin : boolean;


  onSubmit() {
    var email = this.addForm.controls['email'].value;
    var password = this.addForm.controls['password'].value;
    this.validateLogin(email,password);
  }

  validateLogin(email:string, password:string){
    this.service.login(email,password)
      .subscribe(
        data => {
          const token = (<any>data).token;
          localStorage.setItem("JWT",token);
          this.invalidLogin = false;
          this.router.navigateByUrl('/switch');
          window.location.reload();
          
          //this.message = responseProductData;
        }, err => {
          this.invalidLogin = true;
        });
  }

}
