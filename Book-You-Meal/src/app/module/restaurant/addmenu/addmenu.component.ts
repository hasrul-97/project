import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { RestaurantService } from '../../../shared/services/restaurant.service';
@Component({
  selector: 'app-addmenu',
  templateUrl: './addmenu.component.html',
  styleUrls: ['./addmenu.component.css']
})
export class AddmenuComponent implements OnInit {
  registerForm: FormGroup;
  selectedFile = null;
  submitted = false;
  public restaurentList;
  checkimagefile = false;
  itemtypedata
  itemcategorydata
  adddata
  constructor(private spinner: NgxSpinnerService, private formBuilder: FormBuilder, public RestaurantService: RestaurantService) { }

  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
    this.registerForm = this.formBuilder.group({
      restaurantImage: [''],
      restaurantName: ['', [Validators.required, Validators.pattern("(?=.*[a-zA-Z].*)[0-9A-Za-z ]+")]],
      itemType: [''],
      itemCategory: [''],
      itemPrice: ['', [Validators.required]]
    });

    this.RestaurantService.GetItemType().subscribe(data => {
      console.log("all data : ", data);
      this.itemtypedata = data;
    }, error => {
      console.log("all data : ", error);
    })

    this.RestaurantService.GetItemCategory().subscribe(data => {
      this.itemcategorydata = data;
      console.log("all data : ", data);
    }, error => {
      this.itemcategorydata = [];
    })

  }
  fileToUpload;
  onFileSelected(event) {
    console.log(event, "HEllo image");
    this.selectedFile = event.target.files[0];
    let formData: FormData = new FormData();
    formData.append("asset", this.selectedFile, this.selectedFile.name);
    this.fileToUpload = formData;
    console.log(this.selectedFile, "HEllosdsjsjsgj");

    if (this.selectedFile != null) {
      const ext = this.selectedFile.name.split('.')[1].toLowerCase();

      if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "svg") {
        this.checkimagefile = false;
        return true;
      }
    } else {
      this.checkimagefile = true;
      return false;
    }
  }
  img;
  AddItem(itemtype, itemcategory) {
    this.submitted = true;
    let name = this.registerForm.value["restaurantName"];
    if (this.selectedFile == null) {
    } else {
      this.img = this.selectedFile.name;

    }
    this.RestaurantService.UploadImage(this.fileToUpload).subscribe((data) => {
      let value: object = data;
      console.log(value)
    },
      (error) => { console.log(error); })

    this.RestaurantService.AddItem(name, itemtype.value, itemcategory.value, this.registerForm.value["itemPrice"], this.img).subscribe(
      data => {
        this.adddata = data;
        alert(data["message"])
      },
      error => {
        this.adddata = error;
        alert(error.error["message"])
      }
    );
    this.checkimagefile = false;
  }

}




