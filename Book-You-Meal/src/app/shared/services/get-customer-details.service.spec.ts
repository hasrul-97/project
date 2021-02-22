import { TestBed } from '@angular/core/testing';

import { GetCustomerDetailsService } from './get-customer-details.service';
import {HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';

describe('GetCustomerDetailsService', () => {
  
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: GetCustomerDetailsService = TestBed.get(GetCustomerDetailsService);
    expect(service).toBeTruthy();
  });
});
