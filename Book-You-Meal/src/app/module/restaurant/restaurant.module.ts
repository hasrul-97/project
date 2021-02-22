import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RestaurantRoutingModule } from './restaurant-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TestComponent } from './test/test.component';
import { EditmenuComponent } from './editmenu/editmenu.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ProfileComponent } from './profile/profile.component';
import { AddmenuComponent } from './addmenu/addmenu.component';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';


@NgModule({
  declarations: [DashboardComponent, TestComponent, EditmenuComponent, ProfileComponent, AddmenuComponent],
  imports: [
    CommonModule,
    RestaurantRoutingModule,
    NgxSpinnerModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class RestaurantModule { }
