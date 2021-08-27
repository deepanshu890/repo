import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, Subscription } from 'rxjs';
import { ITeam } from 'src/app/models/team';
import { IUser } from 'src/app/models/user';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { AddTeamComponent } from '../../team/add-team/add-team.component';

@Component({
  selector: 'app-view-account',
  templateUrl: './view-account.component.html',
  styleUrls: ['./view-account.component.css']
})
export class ViewAccountComponent implements OnInit,AfterViewInit {
  AccountId: number;

  constructor(private service: ServiceService,private dialog: MatDialog,private router: Router,private route:ActivatedRoute) { }
  userSubscription : Subscription;
  TeamList: any[] = [];
  displayedColumns: string[] = ['teamName'];
  dataSource = new MatTableDataSource<ITeam>(this.TeamList);
  UserList:IUser[] = [];

  ngOnInit(): void {
    this.AccountId=this.route.snapshot.params['accountId']
    console.log(this.AccountId)
    this.getTeamList(this.AccountId);
  }

  ngAfterViewInit() {
    
  }

  onAdd(teamId:number){
    this.router.navigate(['/addTeamMember', teamId]);
  }


  getTeamList(accountId : number) {
   forkJoin([
    this.service.getTeamOne(accountId),
    this.service.getTeamList(),
    this.service.getTeamUser(),
    this.service.getEmployeeList()
   ]).subscribe(
     data =>{
      this.TeamList = data;
      console.log(data);
     }
   )}

   onCreate(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    //dialogConfig.width = "100%";
    this.dialog.open(AddTeamComponent ,{
      height: '400px',
      width: '600px',
    });
    
  }

  //  onOpen(teamId : number){
  //    console.log(teamId)
  //    this.userSubscription = this.service.getTeamMembers(teamId).subscribe(data => {
  //      this.UserList = data;
  //      //console.log(this.UserList)
  //    })

  //  }

}
