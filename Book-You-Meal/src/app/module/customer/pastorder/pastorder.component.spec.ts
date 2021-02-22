import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PastorderComponent } from './pastorder.component';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
describe('PastorderComponent', () => {
  let component: PastorderComponent;
  let fixture: ComponentFixture<PastorderComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PastorderComponent ],
      imports:[HttpClientTestingModule,RouterTestingModule]
    })
    .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(PastorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
