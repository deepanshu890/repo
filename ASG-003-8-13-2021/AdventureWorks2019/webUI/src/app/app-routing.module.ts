import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewEmployeeComponent } from './components/view-employee/view-employee.component';
import { SideBarComponent } from './components/side-bar/side-bar.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';

const routes: Routes = [
  { path: 'viewEmployee', component: ViewEmployeeComponent },
  { path: 'sideBar', component: SideBarComponent },
  { path: 'addEmployee', component: AddEmployeeComponent },
  { path: 'view/:id', component: EditEmployeeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
