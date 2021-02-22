import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RestaurantEditComponent } from './restaurant-edit/restaurant-edit.component';
import { ViewCustomerComponent } from './view-customer/view-customer.component';
const routes: Routes = [
  {path:'home',component:DashboardComponent},
  {path:'editRestaurant',component:RestaurantEditComponent},
  {path:'viewCustomer',component:ViewCustomerComponent}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
