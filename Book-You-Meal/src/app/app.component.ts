import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { LoginService } from './shared/services/login.service';
import { LoginComponent } from './module/authentication/login/login.component';
import { AuthService } from 'ng4-social-login';
import { HeaderComponent } from './core/header/header.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  login: LoginComponent;
  private header:HeaderComponent
constructor(private spinner: NgxSpinnerService, private service: LoginService,private social:AuthService,private loginservice:LoginService, private toastr: ToastrService, private route: Router){
  this.login = new LoginComponent(social,loginservice,this.header,route,toastr,spinner);
}
ngOnInit(){
  if (this.service.IsLogedIn()) {
    this.login.GoogleLogin();
  }
  if (localStorage.getItem("roleName").localeCompare("RestaurantOwner") == 0) {
    this.spinner.hide();
    this.route.navigate(['restaurant/home']);
    this.toastr.success("User Login Successful!!");
  } else if (localStorage.getItem("roleName").localeCompare("Admin") == 0) {
    this.spinner.hide();
    this.route.navigate(['admin/home']);
    this.toastr.success("User Login Successful!!");
  }
  else if (localStorage.getItem("roleName").localeCompare("Customer") == 0) {
    this.spinner.hide();
    this.route.navigate(['customer/home']);
    this.toastr.success("User Login Successful!!");
  }
}
title = 'BookYourMeal';
}
