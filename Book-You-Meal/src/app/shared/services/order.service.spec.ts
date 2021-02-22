import { TestBed } from '@angular/core/testing';
import {HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { OrderService } from './order.service';

describe('OrderService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: OrderService = TestBed.get(OrderService);
    expect(service).toBeTruthy();
  });
});
