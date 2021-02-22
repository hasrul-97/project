import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { RestaurantService } from '../../../shared/services/restaurant.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-editmenu',
  templateUrl: './editmenu.component.html',
  styleUrls: ['./editmenu.component.css']
})
export class EditmenuComponent implements OnInit {
  registerForm: FormGroup;
  selectedFile=null;
  submitted = false;
public editdata:any;
public deletedata:any;
public adddata:any;
public updatedata:any;
public itemtypedata:any;
public itemcategorydata:any;
restaurantDetails
ItemId;
restauranItem
checkimagefile=false;
  constructor(public spinner:NgxSpinnerService,private toastr:ToastrService,public RestaurantService:RestaurantService,private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.spinner.show()
    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 2000);

    this.registerForm = this.formBuilder.group({
      restaurantImage: [''],
      restaurantName: ['', [Validators.required,Validators.pattern("(?=.*[a-zA-Z].*)[0-9A-Za-z ]+")]],
      itemType:[''],
      itemCategory:[''],
      itemPrice:['',[Validators.required]]
  });
    let resId=localStorage.getItem("resID");
    
      this.RestaurantService.GetRestaurantItems(resId).subscribe(data => {
        this.restauranItem = data;
        
        console.log(data);
       },error=>{
        console.log(error);
        
      })

      this.RestaurantService.GetItemType().subscribe(data => {
        console.log("all data : ",data);
        this.itemtypedata = data;
       },error=>{
        console.log("all data : ",error);
      })
    
      this.RestaurantService.GetItemCategory().subscribe(data => {
        this.itemcategorydata = data;
        console.log("all data : ",data);
       },error=>{
        this.itemcategorydata=[];
      })
    
   
  }
  setProduct(value){
    this.editProduct=value;
    console.log(this.editProduct)
    return true;
  }
  editProduct;

  onFileSelected(event){
    console.log(event,"HEllo image");
    this.selectedFile=event.target.files[0];
    console.log(this.selectedFile,"HEllosdsjsjsgj");

    if(this.selectedFile!=null ){
      const ext = this.selectedFile.name.split('.')[1].toLowerCase();
      
      if (ext=="png" || ext=="jpg" || ext=="jpeg" || ext=="svg") {
        this.checkimagefile=true;
        
      }
    }else{
      this.checkimagefile=false;
    }
  }

  sendItemId(ItemId)
  {
    this.ItemId=ItemId;
  }
  EditItem(itemtype,itemcategory)
  {
  
    this.submitted = true;
    if (this.registerForm.invalid) {
        return;
    }else if(this.checkimagefile==false){
      return;
    }else if(itemtype.value==undefined)
    {
      return;
    }
      let name=this.registerForm.value["restaurantName"];
      let img;
      if(this.selectedFile==null)
      {
         img='src/app/assets/images/food/food1.jpg';
      }else{
         img=this.selectedFile.name;
      }
    
      this.RestaurantService.EditItem(this.ItemId,name,itemtype.value,itemcategory.value,this.registerForm.value["itemPrice"],img).subscribe(
        data=>{this.adddata=data;
          console.log(this.ItemId,"wefwkrkwjr")
                this.toastr.success(data["message"]);
                this.spinner.show()
                setTimeout(() => {
                  this.spinner.hide();
                }, 2000);
                this.ngOnInit()
              },
       error=>{this.adddata=error;
                alert(error.error["message"])
       }
     );
  this.checkimagefile=false;
  }
 DeleteItem(itemId)
 {
   this.RestaurantService.DeleteItem(itemId).subscribe(
      data=>{this.deletedata=data;
       this.toastr.success(data["message"])
      return true;
      },
     error=>{
       this.deletedata=error;
       alert(error.error["message"])
     }
   );
}

UpdateDiscount(restaurantid,discount)
{
  this.RestaurantService.UpdateDiscount(restaurantid,discount).subscribe(
    data=>{this.updatedata=data;
     this.toastr.success(data["message"])},
   error=>{
     this.updatedata=error;
     alert(error.error["message"])
   }
 );
}
}
