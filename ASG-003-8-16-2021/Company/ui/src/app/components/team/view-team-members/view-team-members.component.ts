import { Component, OnInit, ViewChild,Input } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { IUser } from 'src/app/models/user';
import { AfterViewInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-view-team-members',
  templateUrl: './view-team-members.component.html',
  styleUrls: ['./view-team-members.component.css']
})
export class ViewTeamMembersComponent implements OnInit {

  teamId : number;
  constructor(private service: ServiceService, private router: Router,private dialog: MatDialog,private route: ActivatedRoute) { }
  EmployeeList: IUser[] = [];
  userSubscription: Subscription;
  displayedColumns: string[] = ['userId', 'addressId', 'firstName', 'lastName', 'emailId', 'gender', 'phoneNumber', 'addressLine', 'city', 'state', 'pincode'];
  dataSource = new MatTableDataSource<IUser>(this.EmployeeList);
  id : number = 0;

  status: boolean = false;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit(): void {
   
    this.teamId = this.route.snapshot.params['teamId'];
    this.getUserList(this.teamId);

  }

  getUserList(teamId : number) {
    console.log(teamId)
    this.userSubscription = this.service.getTeamMembers(teamId).subscribe(data => {
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



}
