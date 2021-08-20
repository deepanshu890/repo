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
import { AddUserComponent } from '../add-user/add-user.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.css']
})
export class ViewUserComponent implements OnInit, AfterViewInit,OnDestroy {

  constructor(private service: ServiceService, private router: Router,
    private dialog: MatDialog) { }
  EmployeeList: IUser[] = [];
  initColumns: any[] = [
    {
      name: 'userId',
      display: 'user Id'
    },
    {
      name: 'addressId',
      display: 'Address Id'
    },
    {
      name: 'firstName',
      display: 'First Name'
    },
    {
      name: 'lastName',
      display: 'Last Name'
    },
    {
      name: 'firstName',
      display: 'First Name'
    },
    {
      name: 'emailId',
      display: 'Email Id'
    },
    {
      name: 'gender',
      display: 'Gender'
    },
    {
      name: 'phoneNumber',
      display: 'Phone Number'
    },
    {
      name: 'addressLine',
      display: 'Address'
    },
    {
      name: 'city',
      display: 'City'
    },
    {
      name: 'state',
      display: 'State'
    },
    {
      name: 'pincode',
      display: 'Pincode'
    },
  ];
  userSubscription : Subscription;
  displayedColumns: string[] = ['userId', 'addressId', 'firstName', 'lastName', 'emailId', 'gender', 'phoneNumber', 'addressLine', 'city', 'state', 'pincode', 'actions'];
  dataSource = new MatTableDataSource<IUser>(this.EmployeeList);
  displayed: IUser[] = this.initColumns.map(col => col.name);
  status: boolean = false;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.getUserList();
  }

  getUserList() {
   this.userSubscription= this.service.getEmployeeList().subscribe(data => {
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
      responseRemoveCartProductStatus => {
        this.status = responseRemoveCartProductStatus;
        if (this.status) {
          alert("User deleted successfully.");
          this.ngOnInit();
        }
        else {
          alert("User could not be deleted. Please try after sometime.");
        }
      });
  }

}
