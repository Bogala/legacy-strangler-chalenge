import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserListComponent, UserEditComponent } from './user';

const routes: Routes = [
  { path: '', component: UserListComponent },
  { path: 'edit', component: UserEditComponent }
];

@NgModule({
  exports: [ RouterModule ],
  imports: [ RouterModule.forRoot(routes) ]
})
export class AppRoutingModule {}
