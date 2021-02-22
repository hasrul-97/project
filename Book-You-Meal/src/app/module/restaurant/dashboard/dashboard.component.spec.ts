import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardComponent } from './dashboard.component';
import { ChartsModule } from '../../../../../node_modules/ng2-charts';
import { FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { AppRoutingModule } from '../../../app-routing.module';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { RestaurantFilterPipe } from '../../../shared/pipes/restaurant-filter.pipe';


describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardComponent,RestaurantFilterPipe],
      imports:[ChartsModule,FormsModule,ReactiveFormsModule,AppRoutingModule,HttpClientTestingModule],
     

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
});
