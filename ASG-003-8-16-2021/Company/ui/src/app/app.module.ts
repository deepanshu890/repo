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



@NgModule({
  declarations: [
    AppComponent,
    ViewUserComponent,
    AddUserComponent,
    EditUserComponent,
    ViewTeamComponent,
    AddTeamComponent,
    ViewTeamMembersComponent
  ],
  imports: [
    BrowserModule,HttpClientModule,
    AppRoutingModule,
    MaterialDesignModule,ReactiveFormsModule,FormsModule,
   
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[AddUserComponent,AddTeamComponent]
})
export class AppModule { }
