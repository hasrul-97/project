import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HelpComponent } from './help.component';
import { NgForm, FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
describe('HelpComponent', () => {
  let component: HelpComponent;
  let fixture: ComponentFixture<HelpComponent>;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HelpComponent ],
      imports:[FormsModule,ReactiveFormsModule,HttpClientTestingModule,RouterTestingModule]
    })
    .compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(HelpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
