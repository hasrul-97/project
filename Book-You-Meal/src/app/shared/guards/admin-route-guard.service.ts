import { Injectable } from '@angular/core';
import { CanLoad, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { LoginService } from '../services/login.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AdminRouteGuardService implements CanLoad {
  canLoad(route:Route): boolean{
    let roleName=localStorage.getItem("roleName");
    if(!this.login.IsLogedIn()&&roleName==='Admin')
      return true;
    else
    this.toastr.error("You do not have the required access.");
    
    return false;
  }

  constructor(private toastr:ToastrService,private login:LoginService,private route:Router) { }
}
