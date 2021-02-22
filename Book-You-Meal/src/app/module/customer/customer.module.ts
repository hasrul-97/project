import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerRoutingModule } from './customer-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';
import { MenupageComponent } from './menupage/menupage.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { PaymentComponent } from './payment/payment.component';
import { ItemFilterPipe } from 'src/app/shared/pipes/item-filter.pipe';
import { RestaurantFilterPipe } from '../../shared/pipes/restaurant-filter.pipe';
import { PastorderComponent } from './pastorder/pastorder.component';
@NgModule({
  declarations: [
    DashboardComponent, 
    MenupageComponent, 
    CheckoutComponent,
    ItemFilterPipe,
    PaymentComponent,
    PastorderComponent,
    RestaurantFilterPipe
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    
  ] 
})
export class CustomerModule { }
