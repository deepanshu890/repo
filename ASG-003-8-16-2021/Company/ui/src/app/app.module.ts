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



@NgModule({
  declarations: [
    AppComponent,
    ViewUserComponent,
    AddUserComponent,
    EditUserComponent
  ],
  imports: [
    BrowserModule,HttpClientModule,
    AppRoutingModule,
    MaterialDesignModule,ReactiveFormsModule,FormsModule,
   
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[AddUserComponent]
})
export class AppModule { }
