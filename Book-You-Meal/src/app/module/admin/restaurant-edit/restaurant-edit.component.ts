import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../shared/services/admin.service';
import { NgxSpinnerService } from 'ngx-spinner';
@Component({
  selector: 'app-restaurant-edit',
  templateUrl: './restaurant-edit.component.html',
  styleUrls: ['./restaurant-edit.component.css']
})
export class RestaurantEditComponent implements OnInit {
  public restaurantrequestdata: any;
  public customerdetailsdata: any;
  public restaurantdetailsdata: any;
  public ordderdetailsdata: any;
  public mealdata: any;

  noOfRequest: number = 0;
  registeredRestaurantCount: number = 0
  registeredUserCount: number = 0
  noOfOrderPlaced: number = 0
  approveData
  rejectData
  constructor(public spinner: NgxSpinnerService, public AdminService: AdminService) { }


  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
      console.log(this.restaurantdetailsdata)
    }, 2000);

    this.AdminService.Requestsdetails().subscribe(data => {
      this.restaurantrequestdata = data;
      this.noOfRequest = this.restaurantrequestdata.length
    }, error => {
      this.restaurantrequestdata = [];
    })

    this.AdminService.Customersdetails().subscribe(data => {
      this.customerdetailsdata = data;
      this.registeredUserCount = this.customerdetailsdata.length
    }, error => {
      this.customerdetailsdata = [];
    })

    this.AdminService.Ordersdetails().subscribe(data => {
      this.ordderdetailsdata = data;
      this.noOfOrderPlaced = this.ordderdetailsdata.length
    }, error => {
      this.ordderdetailsdata = [];
    })

    this.AdminService.details().subscribe(data => {
      this.restaurantdetailsdata = data;
      this.registeredRestaurantCount = this.restaurantdetailsdata.length
    }, error => {
      this.restaurantrequestdata = [];

    })

  }


  Reject(id) {
    this.AdminService.Reject(id).subscribe(
      data => { this.rejectData = data; alert(data["message"]);
    this.ngOnInit() },
      error => { this.rejectData = error; alert(error.error["message"]);this.ngOnInit() }
    );
  }
  Approve(id) {
    this.AdminService.Approve(id).subscribe(
      data => { this.approveData = data; alert(data["message"]) },
      error => { this.approveData = error; alert(error.error["message"]) }
    );
  }
  DisableRestaurant(id) {
    this.AdminService.DisableRestaurant(id).subscribe(
      data => {
        this.mealdata = data;
        alert(data["message"])
        this.ngOnInit()
        return true;
      },
      error => {
        this.mealdata = error;
        alert(error.error["message"])
      }
    );
  }
  EnableRestaurent(id) {
    this.AdminService.EnableRestaurent(id).subscribe(
      data => {
        this.mealdata = data;
        alert(data["message"])
        this.ngOnInit();
        return true;
      },
      error => {
        this.mealdata = error;
        alert(error.error["message"])
      }
    );
  }
  flag: boolean = true

  checkFlag(userId): boolean {
    let flag: boolean = false;
    let restaurant;
    console.log("ID: "+userId)
    for (let i = 0; i < this.restaurantdetailsdata.length; i++) {
      if (this.restaurantdetailsdata[i].userId === userId) {
        restaurant = this.restaurantdetailsdata[i]
      }
    }
    console.log(restaurant)
    if (restaurant.activeUserID == 2) {
      flag = true;
    }
    console.log(flag)
    return flag
  }


}
