import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../shared/services/customer.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from '../../../../../node_modules/ngx-toastr';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  registerForm: FormGroup;
  selectedFile = null;
  submitted = false;
  public restaurentList=null;
  public restaurentListCount;
  public bookMarkedrestaurentList;
  public bookMarkedrestaurentListCount;
  checkimagefile = false;
  public itemList;
  public pastOrderList;
  public pastOrderListCount;
  public searchText;
  constructor(private spinner: NgxSpinnerService, public customer: CustomerService, private formBuilder: FormBuilder,private toastr: ToastrService) { }

  customerName
  ngOnInit() {
    this.spinner.show();
    // setTimeout(() => {
    //   this.spinner.hide();
    // }, 4000);

    let lat=localStorage.getItem("Latitude");
    let long=localStorage.getItem("Longitude");
    this.registerForm = this.formBuilder.group({
      restaurantImage: [''],
      restaurantName: ['', [Validators.required, Validators.pattern("(?=.*[a-zA-Z].*)[0-9A-Za-z ]+")]]
    });


    this.customerName = localStorage.getItem("username");

    this.customer.GetAllRestaurent(lat,long).subscribe((data) => {
      console.log(data);
      this.restaurentList = data;
      console.log("restaurant data : ", data);
    }, (error) => {
      console.log(error);
    });
    

    let userId = localStorage.getItem("userID")
    this.customer.GetAllBookMarkedRestaurent(userId).subscribe((data) => {
      console.log(data);
      this.bookMarkedrestaurentList = data;
      localStorage.setItem("Bookmark",JSON.stringify(this.bookMarkedrestaurentList))
      this.bookMarkedrestaurentListCount = this.bookMarkedrestaurentList.length;
    }, (error) => {
      this.bookMarkedrestaurentListCount = 0;
      console.log(error);
    })
    this.customer.GetPastOrder(userId).subscribe((data) => {
      console.log(data, "past order");
      this.pastOrderList = data;
      this.pastOrderListCount = this.pastOrderList.length
      this.spinner.hide();
      }, (error) => {
      this.pastOrderListCount = 0
      console.log(error);
      })

   

    
  }
  onFileSelected(event) {
    console.log(event, "HEllo image");
    this.selectedFile = event.target.files[0];
    console.log(this.selectedFile, "HEllosdsjsjsgj");

    if (this.selectedFile != null) {
      const ext = this.selectedFile.name.split('.')[1].toLowerCase();

      if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "svg") {
        this.checkimagefile = true;
      }
    } else {
      this.checkimagefile = false;
    }



  }
  RegisterRestaurant() {
    this.submitted = true;
    if (this.registerForm.invalid) {
      return;
    } else if (this.checkimagefile == false) {
      return;
    }

    let name = this.registerForm.value["restaurantName"];
    let img;
    if (this.selectedFile == null) {
      img = 'src/app/assets/images/food/food1.jpg';
    } else {
      img = this.selectedFile.name;
    }

    this.customer.RegisterRestaurant(name, img, localStorage.getItem("userID")).subscribe((data) => {
      this.toastr.success(data["message"]);
      //alert(data["message"]);
    }, (error) => {
      this.toastr.error(error.error["message"]);
      //alert(error.error["message"]);
    });
    this.checkimagefile = false;
  }
  EditProfile(name, mobile, location) {
    this.customer.EditProfile(name, mobile, location).subscribe((data) => {
      console.log(data);
    }, (error) => {
      console.log(error);
    });
  }

  check(vegetarian, nonvegetarian, jain) {
    alert("Vegetarian: " + vegetarian + " " + "Non-Vegetarian: " + nonvegetarian + " " + "Jain: " + jain)
  }
  sendRestaurantId(restaurantId) {
    localStorage.setItem("restaurantId", restaurantId);
  }


}
