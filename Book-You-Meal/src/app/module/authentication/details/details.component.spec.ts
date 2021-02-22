import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DetailsComponent } from './details.component';

import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
describe('DetailsComponent', () => {
  let component: DetailsComponent;
  let fixture: ComponentFixture<DetailsComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsComponent ]
    })
    .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
