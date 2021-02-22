import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { NgModule } from '../../node_modules/@angular/core';
import { FormsModule, ReactiveFormsModule } from '../../node_modules/@angular/forms';
import { HeaderComponent } from './core/header/header.component';
import { NgxSpinner } from '../../node_modules/ngx-spinner/lib/ngx-spinner.enum';
import { NgxSpinnerModule } from '../../node_modules/ngx-spinner';
import { LoginComponent } from './module/authentication/login/login.component';
import { ToastrModule } from '../../node_modules/ngx-toastr';
import { HttpClientTestingModule } from '../../node_modules/@angular/common/http/testing';
import { AuthService, AuthServiceConfig } from '../../node_modules/ng4-social-login';
import { provideConfig } from './module/authentication/authentication.module';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,HeaderComponent,LoginComponent
      ],
      imports: [
        RouterTestingModule,FormsModule,ReactiveFormsModule,NgxSpinnerModule,ToastrModule.forRoot(),HttpClientTestingModule],
        providers:[{
          provide:AuthService,AuthServiceConfig,
        useFactory:provideConfig}]
     
    
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'BookYourMeal'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('BookYourMeal');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('.content span').textContent).toContain('BookYourMeal app is running!');
  });
});
