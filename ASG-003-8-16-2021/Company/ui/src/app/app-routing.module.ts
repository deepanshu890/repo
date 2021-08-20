import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewUserComponent } from './components/view-user/view-user.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { ViewTeamComponent } from './components/team/view-team/view-team.component';
import { AddTeamComponent } from './components/team/add-team/add-team.component';
import { ViewTeamMembersComponent } from './components/team/view-team-members/view-team-members.component';

const routes: Routes = [
  { path: 'viewUser', component: ViewUserComponent },
  { path: 'addUser', component: AddUserComponent },
  { path: 'editUser/:userId/:addressId/:firstName/:lastName/:emailId/:gender/:phoneNumber/:addressLine/:city/:state/:pincode', component: EditUserComponent },
  { path: 'viewTeam', component: ViewTeamComponent },
  { path: 'addTeam', component: AddTeamComponent },
  { path: 'viewTeamMember', component: ViewTeamMembersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
