import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../../../shared/services/restaurant.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public editdata:any; 
  registerForm: FormGroup;
  selectedFile=null;
  submitted = false;
  public restaurentList;
  checkimagefile=false;
  itemtypedata
  itemcategorydata
  adddata
  constructor(private spinner:NgxSpinnerService,private formBuilder: FormBuilder,public RestaurantService:RestaurantService) { }
   
  ngOnInit() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 5000);
    this.registerForm = this.formBuilder.group({
      restaurantImage: [''],
      restaurantName: ['', [Validators.required,Validators.pattern("(?=.*[a-zA-Z].*)[0-9A-Za-z ]+")]],
      mobile:['',[Validators.required]],
      address:['',[Validators.required]],
      discount:['',[Validators.required]],
      resavailability:['']
  });


  }
  onSubmit(data:any){

  }

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

EditProfile(resavailability)
{
  this.submitted = true;
  if (this.registerForm.invalid) {
      return;
  }else if(this.checkimagefile==false){
    return;
  }else if(resavailability.value==undefined)
  {
    return;
  }
    let name=this.registerForm.value["restaurantName"];
    let mobile=this.registerForm.value["mobile"];
    let address=this.registerForm.value["address"];
    let discount=this.registerForm.value["discount"];
    let img;

   
    if(this.selectedFile==null)
    {
       img='src/app/assets/images/food/food1.jpg';
    }else{
       img=this.selectedFile.name;
    }
    console.log(name,mobile,address,discount,img,resavailability.value,"wjgevwlirgvi3")
    this.RestaurantService.EditProfile(name,mobile,address,resavailability.value,discount,img).subscribe(
      data=>{this.adddata=data;
              alert(data["message"]);
            },
     error=>{this.adddata=error;
              alert(error.error["message"]);
     }
   );
this.checkimagefile=false;
}



}
