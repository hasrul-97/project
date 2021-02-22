import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RestaurantEditComponent } from './restaurant-edit.component';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';

describe('RestaurantEditComponent', () => {
  let component: RestaurantEditComponent;
  let fixture: ComponentFixture<RestaurantEditComponent>;
  var userId;
  var id;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RestaurantEditComponent ],
      imports:[HttpClientTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('checkFlag to be true',()=>{
    expect(component.checkFlag(userId)).toBeTruthy();
  })
  it('checkFlag to be false',()=>{
    expect(component.checkFlag(userId)).toBeFalsy();
  })
  it('disable restaurant to be true',()=>{
    expect(component.DisableRestaurant(id)).toBeTruthy();
  })
  it('disable restaurant to be false',()=>{
    expect(component.DisableRestaurant(id)).toBeFalsy();
  })
  it('enable restaurant to be true',()=>{
    expect(component.EnableRestaurent(id)).toBeTruthy();
  })
  it('enable restaurant to be false',()=>{
    expect(component.EnableRestaurent(id)).toBeFalsy();
  })
});
