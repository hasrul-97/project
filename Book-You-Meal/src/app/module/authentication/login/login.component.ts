import { Component, OnInit } from '@angular/core';
import { AuthService, SocialUser, GoogleLoginProvider, FacebookLoginProvider } from 'ng4-social-login';
import { LoginService } from '../../../shared/services/login.service';
import { Router } from '../../../../../node_modules/@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { HeaderComponent } from 'src/app/core/header/header.component';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userId: string;
  balance:any
  constructor(private socialAuthService: AuthService, private service: LoginService, private header: HeaderComponent, private route: Router, private toastr: ToastrService, private spinner: NgxSpinnerService) { }
  public user: any = SocialUser;
  public loggedIn: boolean;

  ngOnInit() {
    this.socialAuthService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
      console.log(this.user);
    });
  }
  Facebooklogin() {
    this.socialAuthService.signIn(FacebookLoginProvider.PROVIDER_ID).then(userdata => {
      this.user = userdata;

      this.addUser();
    });

  }
  GoogleLogin() {
    this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID).then(userdata => {
      this.user = userdata;
      this.spinner.show()
      this.addUser();
    });
  }
  addUser() {
    this.service
    this.service.Post(this.user, localStorage.getItem("Latitude"), localStorage.getItem("Longitude")).subscribe(() => {
      console.log(this.user);
       
      let rolename;
      
      this.service.getToken(this.user).subscribe(data => {
        console.log(data);
        
        localStorage.setItem("Token", data["token"]);
        
        this.service.getID();
        this.userId = localStorage.getItem("userID");
        this.service.checkDetails(this.user["email"])
        if (localStorage.getItem("roleName").localeCompare("RestaurantOwner") == 0) {
          this.spinner.hide();
          this.route.navigate(['restaurant/home']);
          this.toastr.success("User Login Successful!!");
        } else if (localStorage.getItem("roleName").localeCompare("Admin") == 0) {
          this.spinner.hide();
          this.route.navigate(['admin/home']);
          this.toastr.success("User Login Successful!!");
        }
        else if (localStorage.getItem("roleName").localeCompare("Customer") == 0) {
          this.spinner.hide();
          this.route.navigate(['customer/home']);
          this.toastr.success("User Login Successful !!");
        }
      });
    })

  }
     LogedIn(){
    return !this.service.IsLogedIn();
  }
}



