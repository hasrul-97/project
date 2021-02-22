import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfilePageRoutingModule } from './profile-page-routing.module';
import { ProfilePageDashboardComponent } from './profile-page-dashboard/profile-page-dashboard.component';
import { NgxSpinnerModule } from 'ngx-spinner';


@NgModule({
  declarations: [ProfilePageDashboardComponent],
  imports: [
    CommonModule,
    ProfilePageRoutingModule,
    NgxSpinnerModule
  ]
})
export class ProfilePageModule { }
