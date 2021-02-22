import { TestBed } from '@angular/core/testing';

import { AdminService } from './admin.service';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';

describe('AdminService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: AdminService = TestBed.get(AdminService);
    expect(service).toBeTruthy();
  });
});
