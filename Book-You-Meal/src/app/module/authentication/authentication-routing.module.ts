import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { LandingpageComponent } from '../landingpage/landingpage.component';
import { DashboardComponent } from '../admin/dashboard/dashboard.component';
import { DetailsComponent } from './details/details.component';


const routes: Routes = [
  {
    path:'login',
    component:LoginComponent
  },
  {path:'',component:DashboardComponent},
  {path:'details',component:DetailsComponent}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }
