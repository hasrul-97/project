import { TestBed } from '@angular/core/testing';

import { SignUpService } from './sign-up.service';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { Router } from '../../../../node_modules/@angular/router';
import { NgModule } from '../../../../node_modules/@angular/core';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';

describe('SignUpService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule,RouterTestingModule,FormsModule,ReactiveFormsModule]
  }));

  it('should be created', () => {
    const service: SignUpService = TestBed.get(SignUpService);
    expect(service).toBeTruthy();
  });
});
