import { Component, OnInit,AfterViewInit, ViewChild} from '@angular/core';
import { ServiceService } from '../../shared/service.service';
import { Router } from '@angular/router';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { UserDetails } from '../../models/userDetails';



@Component({
  selector: 'app-view-employee',
  templateUrl: './view-employee.component.html',
  styleUrls: ['./view-employee.component.css']
})


export class ViewEmployeeComponent implements OnInit,AfterViewInit {

  constructor(private service : ServiceService) { }
  EmployeeList:UserDetails[]=[]; 
  displayedColumns : string[]=['firstName','lastName','emailAddress','addressLine1','city','phoneNumber'];
  dataSource = new MatTableDataSource<UserDetails>(this.EmployeeList);
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator ;
  ngOnInit(): void {
    this.getEmployeeList();
  }

  getEmployeeList(){
    this.service.getEmployeeList().subscribe(data => {
      this.dataSource.data = data;     
    })
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
