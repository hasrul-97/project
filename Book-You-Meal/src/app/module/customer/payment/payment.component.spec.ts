import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PaymentComponent } from './payment.component';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
describe('PaymentComponent', () => {
  let component: PaymentComponent;
  let fixture: ComponentFixture<PaymentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentComponent ],
      imports:[HttpClientTestingModule,RouterTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
