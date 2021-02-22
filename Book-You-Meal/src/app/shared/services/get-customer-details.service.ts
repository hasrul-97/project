import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class GetCustomerDetailsService {

  constructor(private http:HttpClient) { }
  postUrl=environment.posturl

  getProfileDetails(userId){
    console.log(userId)
    return this.http.get(this.postUrl+"/Customer/GetProfileDetails?userID="+userId);
  }

}
