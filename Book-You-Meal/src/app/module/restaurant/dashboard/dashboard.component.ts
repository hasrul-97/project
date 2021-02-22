import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { RestaurantService } from '../../../shared/services/restaurant.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
public restaurantDetails
public restauranItem
  constructor(public spinner:NgxSpinnerService,public RestaurantService:RestaurantService) { }
//public restaurantId

  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);

  
    let userId=localStorage.getItem("userID");
    console.log("sdvjsjds",userId);
    
    this.RestaurantService.GetRestaurantDetails(userId).subscribe(data => {
      this.restaurantDetails = data;
      localStorage.setItem("resID",this.restaurantDetails.restaurantId);
      console.log(data);
     },error=>{
      console.log(error);
    })
   
    
  }
 

}
