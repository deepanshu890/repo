import { Component, OnInit,ViewChild,OnDestroy } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { AfterViewInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ITeam } from 'src/app/models/team';
import { AddTeamComponent } from '../add-team/add-team.component';
import { ViewTeamMembersComponent } from '../view-team-members/view-team-members.component';

@Component({
  selector: 'app-view-team',
  templateUrl: './view-team.component.html',
  styleUrls: ['./view-team.component.css']
})
export class ViewTeamComponent implements OnInit {
  durationInSeconds: number = 5;
  private _snackBar: any;

  constructor(private service: ServiceService, private router: Router,
    private dialog: MatDialog) { }
    parentPosts : number[];
    TeamList: ITeam[] = [];
    userSubscription : Subscription;
    displayedColumns: string[] = ['teamId', 'teamName', 'projectName', 'year', 'members', 'isActive','actions'];
    dataSource = new MatTableDataSource<ITeam>(this.TeamList);
    //displayed: ITeam[] = this.initColumns.map(col => col.name);
    status: boolean = false;
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.getTeamList();
  }

  getTeamList() {
    this.userSubscription= this.service.getTeamList().subscribe(data => {
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

  onView(teamId : number){
    this.router.navigate(['/viewTeamMember', teamId]);
  }

  onEdit(prod : any) {
    
    
  }

  onAdd(teamId:number){
    this.router.navigate(['/addTeamMember', teamId]);
  }

  removeTeam(prod : ITeam){
    console.log(prod.teamId)
      this.service.deleteTeam(prod.teamId).subscribe(
        data => {
          if(confirm("Are you sure to delete ?")){
            if (this.status) {
              this._snackBar.open("Team deleted successfully","ok", {
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
