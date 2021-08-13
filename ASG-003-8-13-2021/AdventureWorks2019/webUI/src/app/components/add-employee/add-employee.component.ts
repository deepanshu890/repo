import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../../shared/service.service';
import { FormGroup,FormBuilder } from '@angular/forms';
import { IAddEmployee } from 'src/app/models/IAddEmployee';
import {FormControl, Validators} from '@angular/forms';
@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
  //formValue !: FormGroup;
  employeeModelObj : IAddEmployee = new IAddEmployee();
  employeeData !: any;
  showAdd !: boolean;
  showUpdate !: boolean;
  email = new FormControl('', [Validators.required, Validators.email]);
  firstName = new FormControl('', [Validators.required]);
  lastName = new FormControl('', [Validators.required]);
  address = new FormControl('', [Validators.required]);
  city = new FormControl('', [Validators.required]);
  stateProvinanceId = new FormControl('', [Validators.required]);
  postalCode = new FormControl('', [Validators.required]);
  constructor(public service : ServiceService, private formbuilder : FormBuilder) { }

  formValue = new FormGroup({
    email : new FormControl(),
    firstName : new FormControl(),
    lastName : new FormControl(),
    address : new FormControl(),
    city : new FormControl(),
    stateProvinanceId : new FormControl(),
    postalCode : new FormControl(),
  });

  ngOnInit(): void {

  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  postEmployeeDetails(){
    console.log(this.email.value);
    console.log(this.firstName.value);
    // this.employeeModelObj.lastName = this.formValue.value.lastName;
    // this.employeeModelObj.emailAddress1 = this.formValue.value.emailAddress1;
    // this.employeeModelObj.addressLine1 = this.formValue.value.addressLine1;
    // this.employeeModelObj.city = this.formValue.value.city;
    // this.employeeModelObj.stateProvinanceId = this.formValue.value.stateProvinanceId;
    // this.employeeModelObj.postalCode = this.formValue.value.postalCode;
  }



}
