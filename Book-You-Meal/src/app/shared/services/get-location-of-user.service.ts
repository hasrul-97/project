import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetLocationOfUserService {

  constructor(public http:HttpClient) { }

  getLocationOfUser(latitude: any,longitude: any){
    
     return this.http.get("https://maps.googleapis.com/maps/api/geocode/json?latlng="+latitude+","+longitude+"&key=AIzaSyCVJp9UHSsWCPbQNC_DJ9978tC9BmfN3FY");
     
  }
}
