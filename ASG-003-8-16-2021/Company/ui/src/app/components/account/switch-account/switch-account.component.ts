import { Component, OnInit, ViewChild ,AfterViewInit} from '@angular/core';
 
import { FormBuilder,FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

import { MatDialog,MatDialogConfig } from '@angular/material/dialog';
 
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

import { IAccount } from 'src/app/models/account';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { IUser } from 'src/app/models/user';

@Component({
  selector: 'app-switch-account',
  templateUrl: './switch-account.component.html',
  styleUrls: ['./switch-account.component.css']
})
export class SwitchAccountComponent implements OnInit {

  constructor(private dialog: MatDialog, private fb: FormBuilder, private service: ServiceService,private router: Router) { }
  status: boolean = false;
  formValue : FormGroup;
  durationInSeconds = 5;
  displayedColumns: string[]=['AccountId','AccountName','Actions'];
    listData =new MatTableDataSource<IAccount>();
    @ViewChild(MatSort) sort : MatSort;
    @ViewChild(MatPaginator) paginator : MatPaginator;
     email:string;
  ngOnInit(): void {
    this.getAllAccount();

  }

  getAllAccount(){
    this.service.getAccount().subscribe(data=>{
      this.listData.data=data;          
    })       
  } 
  onClick(AccountId:number){
    var num = AccountId.toString();
    localStorage.setItem("Id",num);
    this.router.navigate(['/viewAccount',AccountId])
  }
 
 
  ngAfterViewInit(){
    this.listData.sort=this.sort;
    this.listData.paginator=this.paginator;
  }
 
 applyFilter(event: Event) {
  const filterValue = (event.target as HTMLInputElement).value;
  this.listData.filter = filterValue.trim().toLowerCase();
 
  }
 

  


}


