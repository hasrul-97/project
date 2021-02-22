import { Injectable } from '@angular/core';
import { CanLoad, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { LoginService } from '../services/login.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class RestaurantGuardService implements CanLoad {
  canLoad(route:Route): boolean {
    let roleName=localStorage.getItem("roleName");
    if(!this.login.IsLogedIn()&&roleName==='RestaurantOwner')
      return true;
    else
    this.toastr.error("You do not have the required access.");
    return false;
  }

  constructor(private toastr:ToastrService,private login:LoginService,private route:Router) { }
}
