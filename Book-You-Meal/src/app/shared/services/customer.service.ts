import { Injectable } from '@angular/core';

import { HttpClient } from '../../../../node_modules/@angular/common/http';
import { environment } from '../../../environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  readonly environmentalurl = environment.posturl;
  constructor(private http: HttpClient) { }

  GetPastOrder(userId)
  {
    return this.http.get(this.environmentalurl+ '/Customer/GetPastOrder?UserId='+userId);
  }
  GetAllRestaurent(lat,long)
  {
    return this.http.get(this.environmentalurl+ '/Customer/GetAllRestaurentLoc?latitude='+lat+ '&longitude='+long);
  }
  GetAllBookMarkedRestaurent(userId)
  {
    return this.http.get(this.environmentalurl+ '/Customer/GetAllBookMarkedRestaurent?UserId='+userId);
  }
  GetProfileDetails(userId)
  {
    return this.http.get(this.environmentalurl+ '/Customer/GetProfileDetails?UserId='+userId);
  }
  EditProfile(name,mobile,location)
  {
    return this.http.post(this.environmentalurl+ '/Customer/EditProfile',{
      "Name":name,
      "UserMobile":mobile,
      "UserLocation":location
    });
  }
  GetResaturentItemDetails(restaurantId) {
    return this.http.get(this.environmentalurl + '/Customer/GetResaturentItemDetails?restaurentId=' + restaurantId);
  }
  RegisterRestaurant(name, img, userId) {
    return this.http.post(this.environmentalurl + '/Customer/RegisterRestaurant', {
      "RestaurantName": name,
      "RestaurantImageUrl": img,
      "UserId": userId
    });
  }
  FilterItems(restaurantId, typeCheck, categoryCheck) {
    return this.http.post(this.environmentalurl + '/Customer/FilteredItems?restaurantId=' + restaurantId, {
      "typefilters": typeCheck,
      "categoryfilters": categoryCheck,
    });
  }
  Search(string) {
    return this.http.post(this.environmentalurl + '/Customer/Search?str=' + string, {});
  }

  BookmarkRestaurant(userID, restaurantID) {
    console.log(userID, restaurantID)
    return this.http.put(this.environmentalurl + "/Order/AddFavouriteRestaurant?UserID=" + userID + "&RestaurantId=" + restaurantID, null)
  }

  RemoveBookmark(userID, restaurantID) {
    return this.http.post(this.environmentalurl + "/Order/RemoveFavouriteRestaurant?UserID=" + userID + "&RestaurantId=" + restaurantID, null)
  }

  GetPastAddress(userID){
    return this.http.get(this.environmentalurl+"/Order/GetAllUserAddress?UserId="+userID);
  }



}
