import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ToastrModule} from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingpageModule } from './module/landingpage/landingpage.module';
import { AuthenticationModule } from './module/authentication/authentication.module';
import { HttpClientModule } from '@angular/common/http';
import { SocialLoginModule } from 'ng4-social-login';
import { CustomerModule } from './module/customer/customer.module';
import { HeaderComponent } from './core/header/header.component';
import { GetLocationOfUserService } from './shared/services/get-location-of-user.service';
import { FormsModule, ReactiveFormsModule } from '../../node_modules/@angular/forms';
import { RestaurantModule } from './module/restaurant/restaurant.module';
import { AdminModule } from './module/admin/admin.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { RouteGuardService } from './shared/guards/route-guard.service';
import { GetCustomerDetailsService } from './shared/services/get-customer-details.service';
import { ProfilePageModule } from './module/profile-page/profile-page.module';
import {ChartsModule} from 'ng2-charts';
import { HelppageModule } from './module/helppage/helppage.module';
import { ItemFilterPipe } from './shared/pipes/item-filter.pipe';
import { RestaurantFilterPipe } from './shared/pipes/restaurant-filter.pipe';




@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    ReactiveFormsModule,
    LandingpageModule,
    CustomerModule,
    RestaurantModule,
    NgxSpinnerModule,
    FormsModule,
    AuthenticationModule,
    HttpClientModule,
    SocialLoginModule,
    BrowserAnimationsModule,
    ProfilePageModule,
    HelppageModule,
    ChartsModule,
      ToastrModule.forRoot({
        timeOut:2000,
        positionClass:'toast-top-right',
        preventDuplicates:true
            })
  ],
  providers: [GetLocationOfUserService,RouteGuardService,GetCustomerDetailsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
