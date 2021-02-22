import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DashboardComponent } from './dashboard.component';
import { FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { RestaurantFilterPipe } from '../../../shared/pipes/restaurant-filter.pipe';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  var name, mobile, location;
  var vegetarian, nonvegetarian, jain;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardComponent,RestaurantFilterPipe,HttpClientTestingModule],
      imports:[FormsModule,ReactiveFormsModule]
    })
    .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('register restuarant to be true',()=>{
    expect(component.RegisterRestaurant()).toBeTruthy();
  })
  it('register restuarant to be false',()=>{
    expect(component.RegisterRestaurant()).toBeFalsy();
  })
  it('editprofile to be true',()=>{
    expect(component.EditProfile(name, mobile, location)).toBeTruthy();
  })
  it('editprofile restuarant to be false',()=>{
    expect(component.EditProfile(name, mobile, location)).toBeFalsy();
  })
  it('check to be true',()=>{
    expect(component.check(vegetarian, nonvegetarian, jain)).toBeTruthy();
  })
  it('check to be false',()=>{
    expect(component.check(vegetarian, nonvegetarian, jain)).toBeFalsy();
  })
  it('onfileselected to be true',()=>{
    expect(component.onFileSelected(event)).toBeTruthy();
  })
  it('onfileselected to be false',()=>{
    expect(component.onFileSelected(event)).toBeFalsy();
  })
});
