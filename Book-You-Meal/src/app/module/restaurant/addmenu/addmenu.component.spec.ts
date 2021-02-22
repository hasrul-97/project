import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddmenuComponent } from './addmenu.component';
import { FormGroup, FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';

describe('AddmenuComponent', () => {
  let component: AddmenuComponent;
  let fixture: ComponentFixture<AddmenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddmenuComponent],
      imports:[FormsModule,ReactiveFormsModule,HttpClientTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddmenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('onFileSelected to be true',()=>{
    expect(component.onFileSelected(event)).toBeTruthy();
  })
  it('onFileSelected to be false',()=>{
    expect(component.onFileSelected(event)).toBeFalsy();
  })
});
