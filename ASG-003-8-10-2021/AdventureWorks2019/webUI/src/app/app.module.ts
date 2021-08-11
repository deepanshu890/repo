import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ViewEmployeeComponent } from './components/view-employee/view-employee.component';
import { ServiceService } from './shared/service.service';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
//import {MatTableDataSource} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import { SideBarComponent } from './components/side-bar/side-bar.component';


@NgModule({
  declarations: [
    AppComponent,
    ViewEmployeeComponent,
    SideBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,ReactiveFormsModule,MatTableModule,MatToolbarModule,
    MatPaginatorModule,MatSortModule,MatFormFieldModule,MatInputModule,
    MatSidenavModule,MatListModule,MatIconModule
    
  ],
  exports:[
    MatTableModule,MatToolbarModule,
    MatPaginatorModule,MatSortModule,MatFormFieldModule,MatInputModule,
    MatSidenavModule,MatListModule,MatIconModule
  ],
  providers: [ServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
