import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilePageDashboardComponent } from './profile-page-dashboard.component';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';

describe('ProfilePageDashboardComponent', () => {
  let component: ProfilePageDashboardComponent;
  let fixture: ComponentFixture<ProfilePageDashboardComponent>;
  let photoUrl:any;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfilePageDashboardComponent ],
      imports:[HttpClientTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfilePageDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
