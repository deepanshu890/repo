import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewUserComponent } from './components/view-user/view-user.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { ViewTeamComponent } from './components/team/view-team/view-team.component';
import { AddTeamComponent } from './components/team/add-team/add-team.component';
import { ViewTeamMembersComponent } from './components/team/view-team-members/view-team-members.component';
import { AddTeamMemberComponent } from './components/team/add-team-member/add-team-member.component';
import { ViewAccountComponent } from './components/account/view-account/view-account.component';
import { ConfirmComponent } from './components/confirm-box/confirm/confirm.component';
import { SwitchAccountComponent } from './components/account/switch-account/switch-account.component';
import { LoginComponent } from './components/login/login/login.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthService } from './service/auth-service/auth.service';
import { AccountUsersComponent } from './components/account/account-users/account-users.component';


const routes: Routes = [
  { path: 'viewUser', component: ViewUserComponent, canActivate:[AuthService] },
  { path: 'addUser', component: AddUserComponent ,canActivate:[AuthService]},
  { path: 'editUser/:userId/:addressId/:firstName/:lastName/:emailId/:gender/:phoneNumber/:addressLine/:city/:state/:pincode', component: EditUserComponent ,canActivate:[AuthService]},
  { path: 'viewTeam', component: ViewTeamComponent,canActivate:[AuthService] },
  { path: 'addTeam', component: AddTeamComponent ,canActivate:[AuthService]},
  { path: 'viewTeamMember/:teamId', component: ViewTeamMembersComponent,canActivate:[AuthService] },
  { path: 'addTeamMember/:teamId', component: AddTeamMemberComponent,canActivate:[AuthService] },
  { path: 'viewAccount/:accountId', component: ViewAccountComponent ,canActivate:[AuthService]},
  { path: 'confirm', component: ConfirmComponent ,canActivate:[AuthService]},
  { path: 'switch', component: SwitchAccountComponent,canActivate:[AuthService] },
  { path: 'accountUsers', component: AccountUsersComponent,canActivate:[AuthService] },
  // { path: 'login', component: LoginComponent },
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
