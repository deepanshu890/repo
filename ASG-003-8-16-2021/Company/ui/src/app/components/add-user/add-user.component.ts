import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, Validators } from '@angular/forms';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  constructor(private dialog: MatDialog, private fb: FormBuilder, private service: ServiceService,private router: Router) { }

  addForm = this.fb.group({
    first: ['', Validators.required],
    last: ['', Validators.required],
    email: ['', Validators.required],
    mobile: ['', Validators.required],
    city: ['', Validators.required],
    gender: ['', Validators.required],
    address: ['', Validators.required],
    state: ['', Validators.required],
    pin: ['', Validators.required]
  });

  ngOnInit(): void {
  }

  onClear() {

  }

  onClose() {

  }

  onSubmit() {
    var firstName = this.addForm.controls['first'].value;
    var lastName = this.addForm.controls['last'].value;
    var emailId = this.addForm.controls['email'].value;
    var mobile = this.addForm.controls['mobile'].value;
    var city = this.addForm.controls['city'].value;
    var gender = this.addForm.controls['gender'].value;
    var address = this.addForm.controls['address'].value;
    var state = this.addForm.controls['state'].value;
    var pin = this.addForm.controls['pin'].value;
    this.adduser(firstName, lastName, emailId, mobile, city, gender, address, state, pin);
  }

  adduser(firstName: string, lastName: string, emailId: string, mobile: string, city: string, gender: string, address: string, state: string, pin: number) {

    this.service.addUser(firstName,lastName,emailId,mobile,city,gender,address,state,pin)
      .subscribe(
        responseProductData => {
          //this.message = responseProductData;
          if (responseProductData) {
            alert("User added sucessfully.")
            this.ngOnInit();
          }
          this.router.navigate(['/viewUser']);
        }
      );

  }

}
