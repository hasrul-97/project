import { TestBed } from '@angular/core/testing';
import { RouteGuardService } from './route-guard.service';
import { ToastrModule } from '../../../../node_modules/ngx-toastr';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { NgModule } from '../../../../node_modules/@angular/core';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';

describe('RouteGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule,ToastrModule.forRoot(),RouterTestingModule,NgModule]
  }));

  it('should be created', () => {
    const service: RouteGuardService = TestBed.get(RouteGuardService);
    expect(service).toBeTruthy();
  });
});
