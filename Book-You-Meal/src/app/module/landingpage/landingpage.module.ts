import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingpageComponent } from './landingpage.component';
import { LangindpageRoutingModule } from './landingpage-routing.module';
import { LoginComponent } from '../authentication/login/login.component';
import { AuthenticationModule } from '../authentication/authentication.module';
import { NgxSpinnerModule } from 'ngx-spinner';



@NgModule({
  declarations: [LandingpageComponent],
  imports: [
    CommonModule,
    LangindpageRoutingModule,
    AuthenticationModule,
    NgxSpinnerModule
  ]
})
export class LandingpageModule { }
