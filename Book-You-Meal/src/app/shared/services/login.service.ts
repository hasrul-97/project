import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '../../../../node_modules/@angular/router';
import { environment } from 'src/environments/environment.prod';
import * as jwt_decode from '../../../../node_modules/jwt-decode'

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  environmenturl = environment.posturl
  connection = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  token: any;
  id: any;
  roleName: any;
  userId: any;

  constructor(private http: HttpClient, private router: Router) { }
  GetUserName() {
    return localStorage.getItem("username");
  }
  Post(data: any, lat: any, lon: any) {
    console.log(data);
    data.Latitude = lat
    data.Longitude = lon
    localStorage.setItem("username", data.name);
    console.log(localStorage.getItem("username"));
    return this.http.post(this.environmenturl + '/Login/AddUser', JSON.stringify(data), this.connection)

  }
  checkDetails(data1: any) {
    return this.http.get(this.environmenturl + '/Login/GetUserDetails?email=' + data1).subscribe(
      (data) => {
        console.log(data)
        if (data['userMobile'] == null) {
          this.router.navigate(['/login/details']);
        }
        else {
          return
        }
      });
  }
  getUserId() {

  }
  getToken(data: any) {
    return this.http.post(this.environmenturl + '/Auth/GetToken', data);
  }
  getID() {
    this.token = localStorage.getItem("Token");
    var id = jwt_decode(this.token);
    this.userId = id["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    this.roleName = id["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    console.log(this.userId, "Customer User Idddddddddddddddddddddddddddd")
    localStorage.setItem("userID", this.userId);
    localStorage.setItem("roleName", this.roleName)
  }

  IsLogedIn() {
    if (localStorage.getItem("Token") != null) {
      return false;
    }
    else {
      return true;
    }
  }
  GetRoleName() {
    return localStorage.getItem("roleName");
  }

  AddUserDetails(data: any) {
    console.log(data)
    return this.http.post(this.environmenturl+'/Login/AddUserDetails?userId=' + localStorage.getItem("userID") + '&mobile=' + data, null)
  }
}