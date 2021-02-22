import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TestComponent } from './test/test.component';
import { EditmenuComponent } from './editmenu/editmenu.component';
import { ProfileComponent } from './profile/profile.component';
import { AddmenuComponent } from './addmenu/addmenu.component';


const routes: Routes = [
  {path:'home', component:DashboardComponent},
  {path:'test',component:TestComponent},
  {path:'edit',component:EditmenuComponent},
  {path:'profile',component:ProfileComponent},
  {path:'addMenu',component:AddmenuComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RestaurantRoutingModule { }
