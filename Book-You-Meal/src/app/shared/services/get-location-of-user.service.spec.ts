import { TestBed } from '@angular/core/testing';

import { GetLocationOfUserService } from './get-location-of-user.service';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';

describe('GetLocationOfUserService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: GetLocationOfUserService = TestBed.get(GetLocationOfUserService);
    expect(service).toBeTruthy();
  });
});
