import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DashboardComponent } from '../admin/dashboard/dashboard.component';
import { RestaurantEditComponent } from '../admin/restaurant-edit/restaurant-edit.component';
import { ViewCustomerComponent } from '../admin/view-customer/view-customer.component';
import { NgxSpinnerModule} from 'ngx-spinner';
import {ChartsModule} from 'ng2-charts';

@NgModule({
  declarations: [DashboardComponent,RestaurantEditComponent,ViewCustomerComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgxSpinnerModule,
    ChartsModule
  ]
})
export class AdminModule { }
