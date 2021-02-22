import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/shared/services/customer.service';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
@Component({
  selector: 'app-pastorder',
  templateUrl: './pastorder.component.html',
  styleUrls: ['./pastorder.component.css']
})
export class PastorderComponent implements OnInit {
  constructor(private customer: CustomerService, private router: Router, private spinner: NgxSpinnerService) { }
  pastOrderList: any
  pastHistory = [{
    "OrderID": "12345",
    "RestaurantName": "TestRestaurant",
    "OrderDetails": ["Item1", "Item2", "Item3"],
    "OrderQuantity": ["5", "3", "2"],
    "ItemPrice": ["10", "20", "30"],
    "OrderPrice": "1000",
    "OrderValue": "150.00"
  }]

  ngOnInit() {
    this.spinner.show();
    let userId = localStorage.getItem("userID")
    this.customer.GetPastOrder(userId).subscribe((data) => {
      console.log(data, "past order");
      this.pastOrderList = data;
      this.spinner.hide();
    }, (error) => {
      console.log(error);
    })
  }
  cartValue
  Reorder() {
    this.cartValue.push({

    })
  }
  reorder(past) {
    console.log(past)
    let productValue = []
    for (let j = 0; j < past.itemDetails.length; j++) {
      productValue.push({
        "ProductId": past.itemDetails[j].itemId,
        "ProductName": past.itemDetails[j].itemName,
        "Quantity": past.itemDetails[j].quantity,
        "Price": past.itemDetails[j].itemPrice
      })
    }
    console.log(productValue)
    localStorage.setItem("CartValue", JSON.stringify(productValue));
    this.router.navigate(['/customer/cart']);
  }

}
