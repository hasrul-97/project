import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MenupageComponent } from './menupage/menupage.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { PaymentComponent } from './payment/payment.component';
import { PastorderComponent } from './pastorder/pastorder.component';
const routes: Routes = [
  {path:'home',component:DashboardComponent},
  {path:'menu',component:MenupageComponent},
  {path:'cart',component:CheckoutComponent},
  {path:'payment',component:PaymentComponent},
  { path:'past',component:PastorderComponent}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
