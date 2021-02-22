import { Component, OnInit } from '@angular/core';
import { NgForm } from '../../../../../node_modules/@angular/forms';
import { LoginService } from '../../../shared/services/login.service';

import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  constructor(private service: LoginService, private route: Router) { }

  ngOnInit() {

  }
  onSubmit(formGroup: any) {
    this.service.AddUserDetails(formGroup.userMobile).subscribe((data) => {
      console.log(data);
      let roleName = localStorage.getItem("roleName")
      let roleNameURL = roleName.toLowerCase()
      if (roleNameURL == "restaurantowner") {
        roleNameURL = "restaurant"
      }
      this.route.navigate(['/' + roleNameURL + '/home']);
    });
  }
}