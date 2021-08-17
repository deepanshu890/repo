import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  firstName : string;
  userId : number;
  addressId : number;
  lastName : string;
  emailId : string;
  mobileNumber : string;
  city : string;
  gender : string;
  address : string;
  state : string;
  pin : number;
  status : boolean = false;

  constructor( private fb: FormBuilder, private service: ServiceService,private router: Router,private route: ActivatedRoute) { }



  ngOnInit(): void {
    this.userId = this.route.snapshot.params['userId'];
    this.addressId = this.route.snapshot.params['addressId'];
    this.emailId = this.route.snapshot.params['emailId'];
    this.firstName = this.route.snapshot.params['firstName'];
    this.lastName = this.route.snapshot.params['lastName'];
    this.gender = this.route.snapshot.params['gender'];
    this.mobileNumber = this.route.snapshot.params['phoneNumber'];
    this.address = this.route.snapshot.params['addressLine'];
    this.city = this.route.snapshot.params['city'];
    this.state = this.route.snapshot.params['state'];
    this.pin = this.route.snapshot.params['pincode'];
    //this.addForm.controls['firstName'].setValue(this.firstName);
  }

  onSubmit(form : any) {
    this.service.updateUser(this.userId,this.addressId,form.userfirstName,form.userlastName,form.useremailId,
      form.usermobileNumber,form.userCity,form.userGender,form.userAddress,form.userState,form.userPin).subscribe(
      responseUpdateCartStatus => {
        this.status=responseUpdateCartStatus;
        if (this.status) {
          alert("Product quantity updated successfully.");
          this.ngOnInit();
          this.router.navigate(['/viewUser']);
        }
        else {
          alert("Some error occured, please try after some time.");
        }
      });
   //console.log(form.userfirstName)
 
  }

}
