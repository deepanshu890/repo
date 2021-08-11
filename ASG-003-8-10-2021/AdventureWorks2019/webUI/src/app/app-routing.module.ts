import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewEmployeeComponent } from './components/view-employee/view-employee.component';
import { SideBarComponent } from './components/side-bar/side-bar.component';
const routes: Routes = [
  { path: 'viewEmployee', component: ViewEmployeeComponent },
  { path: 'sideBar', component: SideBarComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
