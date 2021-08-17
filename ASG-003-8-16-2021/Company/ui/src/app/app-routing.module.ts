import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewUserComponent } from './components/view-user/view-user.component';
import { AddUserComponent } from './components/add-user/add-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';

const routes: Routes = [
  { path: 'viewUser', component: ViewUserComponent },
  { path: 'addUser', component: AddUserComponent },
  { path: 'editUser/:userId/:addressId/:firstName/:lastName/:emailId/:gender/:phoneNumber/:addressLine/:city/:state/:pincode', component: EditUserComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
