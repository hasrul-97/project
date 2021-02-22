import { TestBed } from '@angular/core/testing';
 
import { RestaurantService } from './restaurant.service';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';

describe('RestaurantService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: RestaurantService = TestBed.get(RestaurantService);
    expect(service).toBeTruthy();
  });
});
