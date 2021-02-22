import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckoutComponent } from './checkout.component';
import { NgForm, FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';

describe('CheckoutComponent', () => {
  let component: CheckoutComponent;
  let fixture: ComponentFixture<CheckoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckoutComponent ],
      imports:[FormsModule,ReactiveFormsModule,RouterTestingModule,HttpClientTestingModule]
    
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('past address true',() =>{
    expect(component.PastAddress()).toBeFalsy();
  })
  it('past address false',() =>{
    expect(component.PastAddress()).toBeTruthy();
  })
  it('new address true',() =>{
    expect(component.NewAddress()).toBeFalsy();
  })
  it('past address false',() =>{
    expect(component.NewAddress()).toBeTruthy();
  })
  it('check address true',() =>{
    expect(component.checkAddress()).toBeFalsy();
  })
  it('past address false',() =>{
    expect(component.PastAddress()).toBeTruthy();
  })
});
