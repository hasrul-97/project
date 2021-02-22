import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RouteGuardService } from './shared/guards/route-guard.service';
import { AdminRouteGuardService } from './shared/guards/admin-route-guard.service';
import { RestaurantGuardService } from './shared/guards/restaurant-guard.service';


const routes: Routes = [
  { path: 'test', loadChildren: './module/landingpage/landingpage.module#LandingpageModule'},
  { path: 'admin',canLoad:[AdminRouteGuardService], loadChildren: './module/admin/admin.module#AdminModule'},
  { path: 'login', loadChildren:'./module/authentication/authentication.module#AuthenticationModule' },
  { path: 'customer',canLoad:[RouteGuardService] , loadChildren: './module/customer/customer.module#CustomerModule'},
  { path:'restaurant',canLoad:[RestaurantGuardService] , loadChildren:'./module/restaurant/restaurant.module#RestaurantModule'},
  { path:'profile',loadChildren:'./module/profile-page/profile-page.module#ProfilePageModule'},
  { path:'help',loadChildren:'./module/helppage/helppage.module#HelppageModule'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{useHash:true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
