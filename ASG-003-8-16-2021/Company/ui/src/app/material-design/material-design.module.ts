import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
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
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatMenuModule} from '@angular/material/menu';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTableModule,MatToolbarModule,MatPaginatorModule,MatSortModule,MatFormFieldModule,
    MatInputModule,MatSidenavModule,MatListModule,MatIconModule,MatDividerModule,MatMenuModule,
    MatCardModule,BrowserAnimationsModule,MatDialogModule,MatButtonModule,MatGridListModule,
  ],
  exports: [
    MatTableModule,MatToolbarModule,MatPaginatorModule,MatSortModule,MatFormFieldModule,
    MatInputModule,MatSidenavModule,MatListModule,MatIconModule,MatDividerModule,MatMenuModule,
    MatCardModule,BrowserAnimationsModule,MatDialogModule,MatButtonModule,MatGridListModule,
  ]
})
export class MaterialDesignModule { }
