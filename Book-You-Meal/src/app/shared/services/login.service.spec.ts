import { TestBed } from '@angular/core/testing';

import { LoginService } from './login.service';
import { HttpClientTestingModule } from '../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../node_modules/@angular/router/testing';

describe('LoginService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule,RouterTestingModule]
  }));

  it('should be created', () => {
    const service: LoginService = TestBed.get(LoginService);
    expect(service).toBeTruthy();
  });
});
