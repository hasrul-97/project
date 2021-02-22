import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HeaderComponent } from './header.component';
import { LoginComponent } from '../../module/authentication/login/login.component';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';
import {  ToastrModule, ToastrService } from '../../../../node_modules/ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';
import { AuthService, AuthServiceConfig } from '../../../../node_modules/ng4-social-login';
import { provideConfig } from '../../module/authentication/authentication.module';
import { GetLocationOfUserService } from '../../shared/services/get-location-of-user.service';
import { SignUpService } from '../../shared/services/sign-up.service';
import { LoginService } from '../../shared/services/login.service';
import { Router } from '../../../../node_modules/@angular/router';
describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;
  let service: GetLocationOfUserService;
  let signservice:SignUpService;
  let loginservice:LoginService;
  let route: Router;
 let toastr: ToastrService
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeaderComponent, LoginComponent ],
      imports: [HttpClientTestingModule,RouterTestingModule,FormsModule,ReactiveFormsModule,ToastrModule.forRoot()],
     providers:[{
      provide:AuthService,AuthServiceConfig,
    useFactory:provideConfig}]
    })
    .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    component=new HeaderComponent(service,signservice,loginservice,route,toastr);
  });
  it('should create', () => {
    expect(component.ngDoCheck()).toBeTruthy();
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
