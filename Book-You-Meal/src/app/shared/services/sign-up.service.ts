import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '../../../../node_modules/@angular/common/http';
import { environment } from '../../../environments/environment.prod';
import { Router } from '../../../../node_modules/@angular/router';
import * as convert from 'node_modules/jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class SignUpService {

  environmenturl=environment.posturl
  connection={
    headers  : new HttpHeaders({'Content-Type':'application/json'})};
  token: any;
  id: any;
  userId: any;
 
    constructor(private http:HttpClient,private router:Router) { }

    Post(data:any,lat:any,lon:any){
     console.log(data);
     data.Latitude=lat;
     data.Longitude=lon;
     localStorage.setItem("username",data.name);
     console.log(localStorage.getItem("username"));
     return this.http.post(this.environmenturl+'/Login/AddUser',JSON.stringify(data),this.connection)
      
}
checkDetails(data:any)
{
  
  return this.http.post(this.environmenturl+'/Login/CheckDetails',JSON.stringify(data),this.connection).toPromise().then(
    (status:number)=>{
      if(status==1)
      {
          this.router.navigate(['details']);
      }
      else
      {
        this.router.navigate(['Signup']);
      }
    }
  )
}
getToken(data:any)
{
  return this.http.post(this.environmenturl+'/Auth/GetToken',data);
}
getID(){
  this.token=localStorage.getItem("Token");
  this.id=convert(this.token);
  this.userId=this.id["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
  localStorage.setItem("userID",this.userId);
}
getRoleName(data:any){
  return this.http.post(this.environmenturl+'/Login/GetRoleName',JSON.stringify(data),this.connection);
}
IsLogedIn()
{
  if(localStorage.getItem("Token")!=null)
  {
    return false;
  }
  else{
    return true;
  }
}
}
