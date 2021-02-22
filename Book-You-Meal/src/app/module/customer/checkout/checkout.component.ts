import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { OrderService } from '../../../shared/services/order.service';
import { CustomerService } from 'src/app/shared/services/customer.service';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  constructor(private router: Router, private spinner: NgxSpinnerService, private service: OrderService, private customer: CustomerService) {
    this.discountValue=localStorage.getItem("discount")
    this.discountValue/=100
    console.log(this.discountValue)
   }
  cartDetails
  cartValue = 0;
  address;
  ngOnInit() {
    this.address=localStorage.getItem("Address");
    this.cartValue = 0;
    this.spinner.show()
    setTimeout(() => {
      this.spinner.hide();
    }, 2000);
    this.cartDetails = JSON.parse(localStorage.getItem("CartValue"));
    for (let i = 0; i < this.cartDetails.length; i++) {
      this.cartValue += this.cartDetails[i].Quantity * this.cartDetails[i].Price
    }
    this.customer.GetPastAddress(localStorage.getItem("userID")).subscribe((data) => {
      this.pastAddressList = data;
      console.log(this.pastAddressList);
    })

    
  }
  
  discountValue;
  pastAddressList
  Address;
  addressID
  AddAddress(val) {
    console.log(val)
    this.Address = val["StreetName"];
    if (this.pastAddressValue) {
      localStorage.setItem("AddressID", this.Address)
    }
    else {
      this.service.AddAddress(this.Address).subscribe((data) => {
        this.addressID = data;
        localStorage.setItem("AddressID", this.addressID["message"])
      });
    }
    this.router.navigate(['/customer/payment'])
  }
  checkAddress() {
    console.log(this.Address)
    if (this.Address == null)
      return true
    else
      return false
  }
  ngDoCheck() {
    if (this.cartDetails.length == 0) {
      alert("Your cart is empty")
      this.router.navigate(['/customer/home'])
    }
  }
  delete(name) {
    console.log(name)
    this.cartDetails = this.cartDetails.filter(item => item.ProductName != name);
    localStorage.setItem("CartValue", JSON.stringify(this.cartDetails))
    this.ngOnInit()
  }
  pastAddressValue: boolean = false;
  PastAddress() {
    this.pastAddressValue = true;
  }
  NewAddress() {
    this.pastAddressValue = false;
  }
}
