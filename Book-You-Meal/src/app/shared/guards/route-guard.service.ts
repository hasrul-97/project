import { Injectable } from '@angular/core';
import { CanActivate, Router, CanLoad } from '@angular/router';
import { LoginService } from '../services/login.service';
import { Route } from '@angular/compiler/src/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class RouteGuardService implements CanLoad{
  canLoad(route:Route): boolean{
    let roleName=localStorage.getItem("roleName");
    if(!this.login.IsLogedIn()&&roleName==='Customer')
      return true;
    else
    this.toastr.error("You do not have the requried access");
      return false;
  }
  constructor(private toastr:ToastrService,private login:LoginService,private route:Router) { }
  
}
