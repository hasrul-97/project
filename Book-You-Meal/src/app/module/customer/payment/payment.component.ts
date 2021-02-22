import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../../shared/services/order.service';
import { Router } from '../../../../../node_modules/@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { CustomerService } from 'src/app/shared/services/customer.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(private service: OrderService, private route: Router, private spinner: NgxSpinnerService,private customer:CustomerService) { }

  ngOnInit() {
    this.name = localStorage.getItem("username");
    this.purchasedPrice = JSON.parse(localStorage.getItem("CartValue"));
    this.service.GetPayment().subscribe(data => { this.totalAmount = parseInt(data['message']) });
    for (const i of this.purchasedPrice) {
      this.finalCartPrice += i.Price * i.Quantity
    }
    this.cartDetails = JSON.parse(localStorage.getItem("CartValue"));
    console.log(this.cartDetails)
    for (let i = 0; i < this.cartDetails.length; i++) {
      this.itemDetails.push({
        "ItemId": this.cartDetails[i].ProductId,
        "Quantity": this.cartDetails[i].Quantity
      })
    }
    this.orderDetails.push({
      "UserId": localStorage.getItem("userID"),
      "TotalCost": this.finalCartPrice,
      "RestaurantId": localStorage.getItem("restaurantId"),
      "AddressID": localStorage.getItem("AddressID"),
      "OrderDetails": this.itemDetails
    })

  }
  money;
  UpdateAmount() {
    this.spinner.show()
    this.service.MakePayment(this.finalCartPrice).subscribe((data) => { console.log("Success");this.service.PlaceOrder(this.orderDetails[0]).subscribe((data) => { alert("Successfully completed your payment. Please wait while we redirect "); this.spinner.hide(); this.route.navigate(['/customer/home']) }); this.spinner.hide(); }, (error) => { alert("You do not have sufficient balance"); this.route.navigate(['/customer/home']) })
    
  }
  finalCartPrice = 0;
  name;
  totalAmount
  purchasedPrice;
  orderDetails = []
  itemDetails = []
  cartDetails


}
