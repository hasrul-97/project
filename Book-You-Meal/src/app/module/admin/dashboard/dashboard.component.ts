import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../shared/services/admin.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public mealdata: any;
  public customerdetailsdata: any;
  public restaurantdetailsdata: any;
  public restaurantrequestdata: any
  public ordderdetailsdata: any;

  public noOfRequest: number = 0;
  public registeredRestaurantCount: number = 0
  public registeredUserCount: number = 0
  public noOfOrderPlaced: number = 0
  public approveData
  public rejectData
  constructor(public spinner: NgxSpinnerService, public AdminService: AdminService) {
  }
  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 4000);

    this.AdminService.Requestsdetails().subscribe(data => {
      this.restaurantrequestdata = data;
      this.noOfRequest = this.restaurantrequestdata.length;
    }, error => {
      this.restaurantrequestdata = [];
    })
    this.AdminService.Ordersdetails().subscribe(data => {
      this.ordderdetailsdata = data;
      this.noOfOrderPlaced = this.ordderdetailsdata.length
    }, error => {
      this.ordderdetailsdata = [];
    })
    this.AdminService.Customersdetails().subscribe(data => {
      this.customerdetailsdata = data;
      this.registeredUserCount = this.customerdetailsdata.length
    }, error => {
      this.restaurantrequestdata = [];
    })
    this.AdminService.details().subscribe(data => {
      this.restaurantdetailsdata = data;
      this.registeredRestaurantCount = this.restaurantdetailsdata.length
      this.barChartData = [
        { data: [this.registeredUserCount, this.registeredRestaurantCount, this.noOfOrderPlaced, this.noOfRequest] }
      ];

    }, error => {
      this.restaurantrequestdata = [];

    })

  }

  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: { xAxes: [{}], yAxes: [{}] }
  };
  public barChartLabels: Label[] = ['Registered Users', 'Registered Restaurants', 'No of Orders Placed', 'Restaurant Approval Request'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = false;
  public barChartPlugins = [];
  public chartColors: any[] = [
    {
      backgroundColor: ["#4e73df", "#1cc88a", "#36b9cc", "#f6c23e"]
    }];

  public barChartData: ChartDataSets[]
  Reject(id) {
    this.AdminService.Reject(id).subscribe(
      data => { this.rejectData = data; alert(data["message"]);
      this.ngOnInit() },
      error => { this.rejectData = error; alert(error.error["message"]) }
    );
  }
  Approve(id) {
    this.AdminService.Approve(id).subscribe(
      data => {
        this.approveData = data; alert(data["message"]);
        this.ngOnInit();
        console.log(data["message"], 'tfgyhuj');
      },
      error => { this.approveData = error; alert(error.error["message"]) }
    );
  }
}
