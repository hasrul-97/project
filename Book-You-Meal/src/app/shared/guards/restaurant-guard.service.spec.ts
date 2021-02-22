import { TestBed } from '@angular/core/testing';

import { RestaurantGuardService } from './restaurant-guard.service';
import { ToastrModule } from '../../../../node_modules/ngx-toastr';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';
import { FormsModule, ReactiveFormsModule } from '../../../../node_modules/@angular/forms';

describe('RestaurantGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[ToastrModule.forRoot(),HttpClientTestingModule,RouterTestingModule,FormsModule,ReactiveFormsModule]
  }));

  it('should be created', () => {
    const service: RestaurantGuardService = TestBed.get(RestaurantGuardService);
    expect(service).toBeTruthy();
  });
});
