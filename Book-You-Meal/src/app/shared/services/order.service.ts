import { Injectable } from '@angular/core';
import { HttpClient } from '../../../../node_modules/@angular/common/http';
import { environment } from '../../../environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class OrderService {
  username:string;
  readonly environmentalurl=environment.posturl;
  constructor(private http:HttpClient) { }
  AddAddress(data){
    return this.http.post(this.environmentalurl+'/Order/AddAddress?address='+data+'&userId='+localStorage.getItem("userID"),null);
    
  }
   
  MakePayment(money){
    console.log(money)
    this.username=localStorage.getItem("userName");
    return this.http.put(this.environmentalurl+'/Payment/UpdateWalletMoney?UserId='+localStorage.getItem('userID')+"&WalletMoney="+money,null);
  }
  GetPayment(){
   return this.http.get(this.environmentalurl+'/Payment/GetWalletMoney?userId='+localStorage.getItem("userID"));
  }
  PlaceOrder(order){
    console.log(order)
    return this.http.post(this.environmentalurl+'/Order/PlaceOrder',order);
  }
}
