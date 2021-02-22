import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private http:HttpClient) { }
  private postUrl=environment.posturl

  sendEmail(firstname,lastname,message,need,email){
      return this.http.post(this.postUrl+"/Restaurant/Mail",{
        "FirstName":firstname,
        "LastName":lastname,
        "Email":email,
        "MessageBody":message,
        "Need":need
      });
  }
}
