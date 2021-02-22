import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.prod';
import { HttpClient } from '../../../../node_modules/@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  readonly environmenturl=environment.posturl;
  constructor(private http:HttpClient) { }

  GetItemType()
  {
    return this.http.get(this.environmenturl+'/Restaurant/GetItemType');
  }
  GetItemCategory()
  {
    return this.http.get(this.environmenturl+'/Restaurant/GetItemCategory');
  }
  GetRestaurantItems(restaurantId)
  {
    return this.http.get(this.environmenturl+'/Restaurant/GetRestaurantItems?restaurantId='+restaurantId);
  }
  GetRestaurantDetails(userId)
  {
    return this.http.get(this.environmenturl+'/Restaurant/GetRestaurantDetails?userId='+userId);
  }
  UpdateDiscount(restaurantId,discounts)
  {
    return this.http.put(this.environmenturl+'/Restaurant/UpdateDiscount?restaurantId='+restaurantId + '&discounts='+discounts,{});
  }
  AddItem(name,itemtype,itemcategory,price,img)
  {
    let resId=localStorage.getItem("resID");
    return this.http.post(this.environmenturl+'/Restaurant/AddItem',{
      "RestaurantId":resId,
      "ItemName":name,
      "ItemTypeId":itemtype,
      "ItemCategoryId":itemcategory,
      "ItemPrice":price,
      "ItemImage":img

    });
  }
  EditItem(ItemId,name,itemtype,itemcategory,price,img)
  {
    return this.http.post(this.environmenturl+'/Restaurant/EditItem',{
      "ItemId":ItemId,
      "ItemName":name,
      "ItemTypeId":itemtype,
      "ItemCategoryId":itemcategory,
      "ItemPrice":price,
      "ItemImage":img
    });
  }
  DeleteItem(itemId)
  {
    return this.http.put(this.environmenturl+'/Restaurant/DeleteItem?itemId='+itemId,{});
  }
  EditProfile(name,mobile,address,resavailability,discount,img)
  {
    let resId=localStorage.getItem("resID");
    console.log(name,mobile,address,discount,img,resavailability,"wjgevwlirgvi3",resId)
    return this.http.post(this.environmenturl+'/Restaurant/EditRestaurantDetails',{
      "RestaurantId":resId,
      "Discounts":discount,
      "RestaurantName":name,
      "RestaurantAvailabilityId":resavailability,
      "UserMobile":mobile,
      "UserLocation":address,
      "RestaurantImageUrl":img
      

    });
  }
  UploadImage(data:File){
      return this.http.post(this.environmenturl+"/BlobStorage/InsertFile",data);
  }
}
