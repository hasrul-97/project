import { TestBed } from '@angular/core/testing';

import { AdminRouteGuardService } from './admin-route-guard.service';
import { ToastrModule } from '../../../../node_modules/ngx-toastr';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';

describe('AdminRouteGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[ToastrModule.forRoot(),HttpClientTestingModule,RouterTestingModule]
  }));

  it('should be created', () => {
    const service: AdminRouteGuardService = TestBed.get(AdminRouteGuardService);
    expect(service).toBeTruthy();
  });
});
