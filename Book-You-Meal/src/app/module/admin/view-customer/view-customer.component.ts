import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../shared/services/admin.service';
import { NgxSpinnerService } from 'ngx-spinner';
@Component({
  selector: 'app-view-customer',
  templateUrl: './view-customer.component.html',
  styleUrls: ['./view-customer.component.css']
})
export class ViewCustomerComponent implements OnInit {
  public restaurantrequestdata:any;
  public customerdetailsdata:any;
  public restaurantdetailsdata:any;
  public ordderdetailsdata:any;
  public mealdata:any;
  constructor(public spinner:NgxSpinnerService,public AdminService:AdminService){}
  noOfRequest: number=0;
  registeredRestaurantCount: number=0
  registeredUserCount: number=0
  noOfOrderPlaced: number=0
  approveData
  rejectData
  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    },2000);
    this.AdminService.Requestsdetails().subscribe(data => {
      this.restaurantrequestdata = data;
      this.noOfRequest = this.restaurantrequestdata.length
    },error=>{
      this.restaurantrequestdata=[];
    })

    this.AdminService.Customersdetails().subscribe(data => {
      this.customerdetailsdata = data;
      this.registeredUserCount = this.customerdetailsdata.length
    },error=>{
      this.customerdetailsdata=[];})

      this.AdminService.Ordersdetails().subscribe(data => {
        this.ordderdetailsdata = data;
        this.noOfOrderPlaced=this.ordderdetailsdata.length
      },error=>{
        this.ordderdetailsdata=[];})
  
    this.AdminService.details().subscribe(data => {
      this.restaurantdetailsdata = data;
      this.registeredRestaurantCount = this.restaurantdetailsdata.length
    },error=>{
      this.restaurantdetailsdata=[];

    })
  }
  Reject(id)
  {
    this.AdminService.Reject(id).subscribe(
      data=>{this.rejectData=data;alert(data["message"])
      this.ngOnInit();
    return true
  },
      error=>{this.rejectData=error;alert(error.error["message"])}
    );
  }
  Approve(id)
  {
    this.AdminService.Approve(id).subscribe(
      data=>{this.approveData=data;alert(data["message"])
      this.ngOnInit();
    return true
  },
      error=>{this.approveData=error;alert(error.error["message"])}
    );
  }
  DisableCustomer(id)
  {
    this.AdminService.DisableCustomer(id).subscribe(
       data=>{this.mealdata=data;
        alert(data["message"])
      this.ngOnInit()
    return true;},
      error=>{
        this.mealdata=error;
        alert(error.error["message"])
      }
    );
 }
}
