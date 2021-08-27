import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
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
  selector: 'app-add-team-member',
  templateUrl: './add-team-member.component.html',
  styleUrls: ['./add-team-member.component.css']
})
export class AddTeamMemberComponent implements OnInit {
  teamId: number;

  constructor(private service: ServiceService, private router: Router,private route: ActivatedRoute) { }
  EmployeeList: IUser[] = [];
  userSubscription : Subscription;
  displayedColumns: string[] = ['firstName', 'lastName', 'emailId', 'gender', 'phoneNumber',  'actions'];
  dataSource = new MatTableDataSource<IUser>(this.EmployeeList);
  status: boolean = false;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.teamId = this.route.snapshot.params['teamId'];
   // console.log(this.teamId)
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

  onAdd(prod : IUser){
    console.log(this.teamId)
    console.log(prod.userId)
    this.service.addTeamMember(this.teamId,prod.userId)
      .subscribe(
        responseProductData => {
          //this.message = responseProductData;
          if (responseProductData) {
            alert("Team Member added sucessfully.")
            this.ngOnInit();
          }
          this.router.navigate(['/viewAccount']);
        }
      );
  }

}
