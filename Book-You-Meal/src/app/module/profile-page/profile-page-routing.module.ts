import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfilePageDashboardComponent } from './profile-page-dashboard/profile-page-dashboard.component';


const routes: Routes = [
  {path:'home',component:ProfilePageDashboardComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfilePageRoutingModule { }
