import { Injectable } from '@angular/core';

import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from '../../../../node_modules/rxjs';
import { environment } from 'src/environments/environment.prod';
@Injectable({
  providedIn: 'root'
})
export class AdminService {

  
  readonly environmenturl=environment.posturl;
  constructor(private http:HttpClient) { }
  Ordersdetails()
  {
    return this.http.get(this.environmenturl+'/Admin/GetOrdersList')
  }
  details()
  {
    return this.http.get(this.environmenturl+'/Admin/GetRestaurantDetails')
  }

  Customersdetails()
  {
    return this.http.get(this.environmenturl+'/Admin/GetUsersList')
  }
  Requestsdetails()
  {
    return this.http.get(this.environmenturl+'/Admin/GetRequestList')
  }
  Reject(id){
    const httpOptions ={headers : new HttpHeaders({'Content-Type':'application/json',"id":id})};
     return this.http.put(this.environmenturl+'/Admin/RejectRestaurant?approveId='+id,httpOptions);
  }
  Approve(id){
    console.log(id,"appprove id");
    
    const httpOptions ={headers : new HttpHeaders({'Content-Type':'application/json',"id":id})};
     return this.http.put<number>(this.environmenturl+'/Admin/ApproveRestaurant?approveId='+id,httpOptions);
  }
  DisableRestaurant(id): Observable<number>{
    const httpOptions ={headers : new HttpHeaders({'Content-Type':'application/json',"id":id})};
     return this.http.put<number>(this.environmenturl+'/Admin/DisableRestaurent?userId='+id,httpOptions);
  }
  DisableCustomer(id): Observable<number>{
    const httpOptions ={headers : new HttpHeaders({'Content-Type':'application/json',"id":id})};
     return this.http.put<number>(this.environmenturl+'/Admin/DisableCustomer?userId='+id,httpOptions);
  }
  EnableRestaurent(id): Observable<number>{
    const httpOptions ={headers : new HttpHeaders({'Content-Type':'application/json',"id":id})};
     return this.http.put<number>(this.environmenturl+'/Admin/EnableRestaurent?userId='+id,httpOptions);
  }

}
