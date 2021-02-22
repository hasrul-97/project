import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DashboardComponent } from './dashboard.component';
import { ChartsModule } from '../../../../../node_modules/ng2-charts';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { AppRoutingModule } from '../../../app-routing.module';
import { NgModel, FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardComponent],
      imports:[ChartsModule,HttpClientTestingModule,FormsModule,ReactiveFormsModule,AppRoutingModule]

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
