import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';
import {HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { AuthService, AuthServiceConfig } from '../../../../../node_modules/ng4-social-login';
import { provideConfig } from '../authentication.module';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
import { LoginService } from '../../../shared/services/login.service';

import { Router } from '../../../../../node_modules/@angular/router';
import { ToastrService } from '../../../../../node_modules/ngx-toastr';
import { NgxSpinnerService } from '../../../../../node_modules/ngx-spinner';
import { HttpClient } from '../../../../../node_modules/@angular/common/http';
import { HeaderComponent } from '../../../core/header/header.component';
class MockedAuthService extends LoginService{
  authenticated=false;
  IsLogedIn(){
    return this.authenticated;
  }
}

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let service:MockedAuthService;
  let http:HttpClient; 
  let auth:AuthService;
  let serv:LoginService;
  let header:HeaderComponent;
  let route: Router;
  let  toastr: ToastrService;
  let spinner: NgxSpinnerService;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LoginComponent], 
      imports:[HttpClientTestingModule,RouterTestingModule],
     providers:[{
      provide:AuthService,AuthServiceConfig,HeaderComponent,
    useFactory:provideConfig}]
    })
    .compileComponents();
  }));  

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
   service=new MockedAuthService(http,route);
    component=new LoginComponent(auth,serv,header,route,toastr,spinner);
  });

  it('loggedIn as true', () => {
    spyOn(service,'IsLogedIn').and.returnValue(false);
    expect(component.LogedIn()).toBeTruthy();
    expect(service.IsLogedIn).toHaveBeenCalled();
  });
  it('loggedIn as false', () => {
    spyOn(service,'IsLogedIn').and.returnValue(true);
    expect(component.LogedIn()).toBeFalsy();
    expect(service.IsLogedIn).toHaveBeenCalled();
  });
});
