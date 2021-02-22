import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { DetailsComponent } from './details/details.component';
import {SocialLoginModule,AuthServiceConfig,GoogleLoginProvider,FacebookLoginProvider} from 'ng4-social-login';
import { LoginService } from '../../shared/services/login.service';
import { FormsModule } from '../../../../node_modules/@angular/forms';
import { AdminModule } from '../admin/admin.module';
import { SignUpService } from '../../shared/services/sign-up.service';
import { NgxSpinnerModule } from 'ngx-spinner';
const config=new AuthServiceConfig([
  {
     id:GoogleLoginProvider.PROVIDER_ID,
    provider:new GoogleLoginProvider('243873092134-q1ueopmv8cqo40rlg0t2boi0l091i9vq.apps.googleusercontent.com')
  },
  {
    id:FacebookLoginProvider.PROVIDER_ID,
    provider:new FacebookLoginProvider('1654461158023452')
  }
],false)
export function provideConfig(){
  return config;
}
@NgModule({
  declarations: [LoginComponent, DetailsComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    AdminModule,
    NgxSpinnerModule,
    FormsModule
  ],
  exports:[LoginComponent,DetailsComponent],
  providers: [LoginService,SignUpService,
    {provide:AuthServiceConfig,useFactory:provideConfig}
  ],
})
export class AuthenticationModule { }
