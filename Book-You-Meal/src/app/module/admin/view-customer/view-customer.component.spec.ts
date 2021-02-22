import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewCustomerComponent } from './view-customer.component';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';

describe('ViewCustomerComponent', () => {
  let component: ViewCustomerComponent;
  let fixture: ComponentFixture<ViewCustomerComponent>;
var id;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewCustomerComponent ],
      imports:[HttpClientTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('disable customer to be true',()=>{
    expect(component.DisableCustomer(id)).toBeTruthy();
  })
  it('disable restaurant to be false',()=>{
    expect(component.DisableCustomer(id)).toBeFalsy();
  })
  it('reject customer to be true',()=>{
    expect(component.Reject(id)).toBeTruthy();
  })
  it('reject customer to be false',()=>{
    expect(component.Reject(id)).toBeFalsy();
  })
  it('approve customer to be true',()=>{
    expect(component.Approve(id)).toBeTruthy();
  })
  it('reject customer to be false',()=>{
    expect(component.Approve(id)).toBeFalsy();
  })
});
