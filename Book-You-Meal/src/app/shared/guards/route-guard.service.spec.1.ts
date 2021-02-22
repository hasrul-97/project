import 'jasmine';
import { TestBed } from '@angular/core/testing';
import { RouteGuardService } from './route-guard.service';
import { ToastrModule } from '../../../../node_modules/ngx-toastr';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { NgModule } from '../../../../node_modules/@angular/core';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';
import { provideConfig } from '../../module/authentication/authentication.module';

describe('RouteGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule,ToastrModule.forRoot(),RouterTestingModule,FormsModule,ReactiveFormsModule],
    providers:[{
      useFactory:provideConfig
    }]
  }));

  it('should be created', () => {
    const service: RouteGuardService = TestBed.get(RouteGuardService);
    expect(service).toBeTruthy();
  });
});
