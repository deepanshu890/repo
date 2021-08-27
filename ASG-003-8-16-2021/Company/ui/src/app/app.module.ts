import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ViewUserComponent } from './components/view-user/view-user.component';
import { MaterialDesignModule } from './material-design/material-design.module';
import { AddUserComponent } from './components/add-user/add-user.component';
import { ReactiveFormsModule } from '@angular/forms';
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
import { AccountUsersComponent } from './components/account/account-users/account-users.component';

export function tokenGetter(){
  return localStorage.getItem("JWT");
}

@NgModule({
  declarations: [
    AppComponent,
    ViewUserComponent,
    AddUserComponent,
    EditUserComponent,
    ViewTeamComponent,
    AddTeamComponent,
    ViewTeamMembersComponent,
    AddTeamMemberComponent,
    ViewAccountComponent,
    ConfirmComponent,
    SwitchAccountComponent,
    LoginComponent,
    AccountUsersComponent
  ],
  imports: [
    BrowserModule,HttpClientModule,
    AppRoutingModule,
    MaterialDesignModule,ReactiveFormsModule,FormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter : tokenGetter,
        allowedDomains : ["localhost:4200"],
        disallowedRoutes : []
      }
    }),
   
  ],
  
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[AddUserComponent,AddTeamComponent]
})
export class AppModule { }
