import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { GetCustomerDetailsService } from 'src/app/shared/services/get-customer-details.service';
import { OrderService } from 'src/app/shared/services/order.service';
import { CustomerService } from 'src/app/shared/services/customer.service';

@Component({
  selector: 'app-profile-page-dashboard',
  templateUrl: './profile-page-dashboard.component.html',
  styleUrls: ['./profile-page-dashboard.component.css']
})
export class ProfilePageDashboardComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService, private customer: CustomerService, private getDetails: GetCustomerDetailsService, private service: OrderService) { }

  userName = localStorage.getItem("username")
  userId = localStorage.getItem("userID")
  userDetails;
  roleName;

  ngOnInit() {
    this.roleName=localStorage.getItem("roleName");
    console.log(this.roleName)
    this.getDetails.getProfileDetails(this.userId).subscribe(data => {
      this.userDetails = data; console.log(data)
      this.spinner.show();

      this.service.GetPayment().subscribe(data => { this.walletAmount = parseInt(data['message']) });


      setTimeout(() => {
        this.spinner.hide();
      }, 2000);
      console.log(this.userId)
    })

    this.customer.GetPastOrder(this.userId).subscribe((data) => {
      console.log(data, "past order");
      this.pastOrderList = data;
      this.pastOrderListCount = this.pastOrderList.length
    }, (error) => {
      this.pastOrderListCount = 0
      console.log(error);
    })

  }

  walletAmount;
  pastOrderList;
  pastOrderListCount;


}
