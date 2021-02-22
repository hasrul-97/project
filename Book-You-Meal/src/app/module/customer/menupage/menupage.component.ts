import { Component, OnInit, PipeTransform } from '@angular/core';
import { CustomerService } from '../../../shared/services/customer.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { DashboardComponent } from '../dashboard/dashboard.component'
import { RestaurantService } from 'src/app/shared/services/restaurant.service';
import { SearchService } from 'src/app/shared/services/search.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-menupage',
  templateUrl: './menupage.component.html',
  styleUrls: ['./menupage.component.css']
})
export class MenupageComponent implements OnInit {

  public itemList=null;
  public restaurantId;
  public restaurantDetails;
  public restaurantList;
  public filterItemList;
  public filterItemListCount;
  public itemtypedata;
  public itemcategorydata;
  public typeCheck = [];
  public categoryCheck = [];
  searchText;
  public bookMarkedrestaurentList;
  constructor(private spinner: NgxSpinnerService, private router: Router, public customer: CustomerService, public RestaurantService: RestaurantService, public search: SearchService) { }

  ngOnInit() {
    this.search.currentmessage.subscribe(searchText => this.searchText = this.searchText)
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 2000);


    console.log(this.productDetails.length)
    this.RestaurantService.GetItemType().subscribe(data => {
      console.log("all data : ", data);
      this.itemtypedata = data;
      console.log(data);
    }, error => {
      console.log("all data : ", error);
      
    })


    this.RestaurantService.GetItemCategory().subscribe(data => {
      this.itemcategorydata = data;
      console.log("all data : ", data);
    }, error => {
      this.itemcategorydata = [];
    })

    let userId = localStorage.getItem("userID")
    this.customer.GetAllBookMarkedRestaurent(userId).subscribe((data) => {
      console.log(data);
      this.bookMarkedrestaurentList = data;
      localStorage.setItem("Bookmark", JSON.stringify(this.bookMarkedrestaurentList))
    }, (error) => {

      console.log(error);
    })
    this.restaurantId = localStorage.getItem("restaurantId");
    this.customer.GetResaturentItemDetails(this.restaurantId).subscribe((data) => {
      console.log(data);
      this.itemList = data;
    }, (error) => {
      this.itemList = null;
      console.log(error.error["message"]);
    });

    let lat=localStorage.getItem("Latitude");
    let long=localStorage.getItem("Longitude");

    this.customer.GetAllRestaurent(lat,long).subscribe((data) => {
      console.log(data);
      this.restaurantList = data;
      for (var i = 0; i < this.restaurantList.length; i++) {
        if (this.restaurantList[i].restaurantId === this.restaurantId) {
          this.restaurantDetails = this.restaurantList[i];
          break;
        }
      }
      console.log("restaurant data1111 : ", this.restaurantDetails); localStorage.setItem("discount",this.restaurantDetails["discounts"]);
    }, (error) => {
      console.log(error);

    });
   
  }

  bookmarked() {
    let flag: boolean = false
    let bookmark = JSON.parse(localStorage.getItem("Bookmark"))
    for (let i = 0; i < bookmark.length; i++) {
      if (this.restaurantId == bookmark[i].restaurantId) {
        console.log(bookmark[i].restaurantId)
        flag = true;
      }
    }
    return flag
  }
  cartTotal: any = 0;
  productDetails = [];
  AddProductToCart(ProductId, productname, price) {
    let flag: Boolean = false
    for (let i = 0; i < this.productDetails.length; i++) {
      if (this.productDetails[i].ProductName === productname) {
        flag = true;
        this.productDetails[i].Quantity += 1
      }
    }
    if (!flag) {
      this.productDetails.push({
        "ProductId": ProductId,
        "ProductName": productname,
        "Quantity": 1,
        "Price": price,
      })
    }
    this.cartTotal += price;
  }

  delete(name) {
    console.log(name)
    let v=this.productDetails.find(x=>x.ProductName==name)
    this.cartTotal-=v.Price*v.Quantity;
    console.log(this.cartTotal)
    this.productDetails = this.productDetails.filter(item => item.ProductName != name);
    
  }
  checkFlag(): boolean {
    if (this.productDetails.length == 0)
      return true
    else
      return false
  }
  FilterItems() {
    this.customer.FilterItems(this.restaurantId, this.typeCheck, this.categoryCheck).subscribe((data) => {
      console.log(data);
      this.filterItemList = data;
      this.itemList = this.filterItemList;
      console.log(this.itemList)
      return true;
    }, (error) => {
      this.itemList = null;
      console.log(error);
    })
  }
  Selectedtype(type) {
    if (!this.typeCheck.includes(type)) {
      this.typeCheck.push(type)
      return true;
    } else {
      let item = this.typeCheck.indexOf(type);
      this.typeCheck.splice(item, 1);
      return false;
    }
    console.log(this.typeCheck);

  }
  SelectedCategory(category) {
    if (!this.categoryCheck.includes(category)) {
      this.categoryCheck.push(category);
      return true;
    } else {
      let cat = this.categoryCheck.indexOf(category);
      this.categoryCheck.splice(cat, 1);
      return false;
    }
    console.log(this.categoryCheck);

  }

  ForwardCart() {
    localStorage.setItem("CartValue", JSON.stringify(this.productDetails));
    this.router.navigate(['/customer/cart'])
   
  }

  newSearch() {
    this.search.changeMessage(this.searchText);
     return true;

  }
  val
  bookmarkRestaurant() {
    this.customer.BookmarkRestaurant(localStorage.getItem("userID"), this.restaurantId).subscribe(data => {
      this.val = data;
      console.log("all data : ", this.val);
      this.ngOnInit();
      return true;
    }, error => {
      this.val = error;
    })
  }

  RemoveBookmark() {
    this.customer.RemoveBookmark(localStorage.getItem("userID"), this.restaurantId).subscribe(data => {
      this.val = data;
      console.log("all data : ", this.val);
      this.ngOnInit();
      return true;
    }, error => {
      this.val = error;
      console.log("all data : ", this.val);
    })
  }

}
