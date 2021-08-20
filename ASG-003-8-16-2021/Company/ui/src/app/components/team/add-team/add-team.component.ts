import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, Validators } from '@angular/forms';
import { ServiceService } from 'src/app/service/user-service/service.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css']
})
export class AddTeamComponent implements OnInit {

  constructor(private dialog: MatDialog, private fb: FormBuilder, private service: ServiceService,private router: Router) { }
  addForm = this.fb.group({
    teamName: ['', Validators.required],
    projectName: ['', Validators.required],
    year: [''],
    members: [''],
    isActive: [''],
  });
  ngOnInit(): void {
  }

  onClear() {

  }

  onClose() {

  }

  onSubmit() {
    var teamName = this.addForm.controls['teamName'].value;
    var projectName = this.addForm.controls['projectName'].value;
    var year = this.addForm.controls['year'].value;
    var members = this.addForm.controls['members'].value;
    var isActive = this.addForm.controls['isActive'].value;
  
    this.adduser(teamName, projectName, year, members, isActive);
  }

  adduser(teamName: string, projectName: string, year: number, members: number, isActive: number) {

    this.service.addTeam(teamName,projectName,year,members,isActive)
      .subscribe(
        responseProductData => {
          //this.message = responseProductData;
          if (responseProductData) {
            alert("Team added sucessfully.")
            this.ngOnInit();
          }
          this.router.navigate(['/viewTeam']);
        }
      );

  }

}
