import { Component, OnInit, OnChanges, DoCheck, ChangeDetectionStrategy, SimpleChanges } from '@angular/core';
import { LoginService } from '../../shared/services/login.service';
import { GetLocationOfUserService } from './../../shared/services/get-location-of-user.service';
import { Route, Router } from '../../../../node_modules/@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SignUpService } from '../../shared/services/sign-up.service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  changeDetection: ChangeDetectionStrategy.Default

})
export class HeaderComponent implements OnInit {
  userName;
  constructor(private locationService: GetLocationOfUserService, public signupservice: SignUpService, public service: LoginService, private route: Router, private toastr: ToastrService) {
    this.roleName = localStorage.getItem("roleName");
    if (this.roleName != null) {
      console.log(this.roleName)
      this.roleNameURL = this.roleName.toLowerCase()
      if (this.roleNameURL == "restaurantowner") {
        this.roleNameURL = "restaurant"
      }
    }
    this.getLocationOfUser();
  }

  roleName: any;
  locationValue: any;
  roleNameURL

  ngOnInit() {
    this.getLocationOfUser();
  }

  ngDoCheck() {
    if (localStorage.getItem("roleName") != this.roleName) {
      this.roleName = localStorage.getItem("roleName")
      this.roleNameURL = this.roleName.toLowerCase()
      if (this.roleNameURL == "restaurantowner") {
        this.roleNameURL = "restaurant"
        return true;
      }
      console.log(this.roleNameURL)
    }
    return false;
  }

  lat: any;
  lon: any;

  getLocationOfUser() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(this.success.bind(this));
    }
  }




  success(Position) {
    console.log("In")
    if (Position != null) {
      this.lat = Position.coords.latitude;
      this.lon = Position.coords.longitude;
      localStorage.setItem("Latitude", this.lat)
      localStorage.setItem("Longitude", this.lon)
      this.fetchLocation();
    }
  }
  error(Position) {
    console.log("Error");
  }
  fetchLocation() {
    this.locationService.getLocationOfUser(this.lat, this.lon).subscribe(
      (data) => { this.locationValue = data['results'][0]['formatted_address']; console.log(data);localStorage.setItem("Address",this.locationValue) },
      (error) => { this.locationValue = error }
    )
  }
  logOut() {
    localStorage.clear();
    this.getLocationOfUser();
    this.route.navigate(['test']);
    this.toastr.success("User Logged Out Successfully!!");
  }
}
