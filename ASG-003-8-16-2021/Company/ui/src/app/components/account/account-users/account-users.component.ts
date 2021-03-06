import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { IUser } from 'src/app/models/user';
import { AfterViewInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AddUserComponent } from '../../add-user/add-user.component';


@Component({
  selector: 'app-account-users',
  templateUrl: './account-users.component.html',
  styleUrls: ['./account-users.component.css']
})
export class AccountUsersComponent implements OnInit {

  durationInSeconds: number = 5;

  constructor(private service: ServiceService, private router: Router,private _snackBar: MatSnackBar,
  private dialog: MatDialog) { }
  EmployeeList: IUser[] = [];
  userSubscription : Subscription;
  displayedColumns: string[] = ['userId', 'firstName', 'lastName', 'emailId', 'gender', 'phoneNumber', 'actions'];
  dataSource = new MatTableDataSource<IUser>(this.EmployeeList);
 // displayed: IUser[] = this.initColumns.map(col => col.name);
  status: boolean = false;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.getUserList();
  }

  getUserList() {
    var userId = localStorage.getItem("Id");
   
    this.userSubscription= this.service.getAccountUsers(userId).subscribe(data => {
       this.dataSource.data = data;
       console.log(data)
     })
   }
 
   ngOnDestroy() {
     this.userSubscription.unsubscribe()
 }
 
   ngAfterViewInit() {
     this.dataSource.paginator = this.paginator;
     this.dataSource.sort = this.sort;
   }
 
   applyFilter(event: Event) {
     const filterValue = (event.target as HTMLInputElement).value;
     this.dataSource.filter = filterValue.trim().toLowerCase();
   }
 
   onCreate() {
     const dialogConfig = new MatDialogConfig();
     dialogConfig.disableClose = true;
     dialogConfig.autoFocus = true;
     //dialogConfig.width = "100%";
     this.dialog.open(AddUserComponent, {
       height: '400px',
       width: '600px',
     });
   }
 
   onEdit(prod : IUser) {
     
     this.router.navigate(['/editUser', prod.userId, prod.addressId, prod.firstName, prod.lastName,
     prod.emailId, prod.gender, prod.phoneNumber,prod.addressLine, prod.city, prod.state,prod.pincode]);
   }
 
   removeUser(prod: IUser) {
     this.service.deleteUser(prod.userId, prod.addressId).subscribe(
       data => {
         this.status = data;
         if(confirm("Are you sure to delete ?")){
           if (this.status) {
             this._snackBar.open("User deleted successfully","ok", {
               duration: this.durationInSeconds * 1000,
             });
             //alert("Team deleted successfully.");
             this.ngOnInit();
           }
           else {
             this._snackBar.open("Something went wrong","ok", {
               duration: this.durationInSeconds * 1000,
             });
             //alert("Something went wrong");
           }}
       });
   }

}
