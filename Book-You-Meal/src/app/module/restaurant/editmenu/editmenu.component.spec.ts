import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditmenuComponent } from './editmenu.component';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';
import { FormGroup, FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { ToastrModule } from '../../../../../node_modules/ngx-toastr';

describe('EditmenuComponent', () => {
  let component: EditmenuComponent;
  let fixture: ComponentFixture<EditmenuComponent>;
  var value,itemId;
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditmenuComponent ],
      imports:[HttpClientTestingModule,FormsModule,ReactiveFormsModule,ToastrModule.forRoot()]
    })
    .compileComponents(); 
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditmenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('onfileselected to be true',()=>{
    expect(component.onFileSelected(event)).toBeTruthy();
  })
  it('onfileselected to be false',()=>{
    expect(component.onFileSelected(event)).toBeFalsy();
  })
  it('setproduct to be true',()=>{
    expect(component.setProduct(value)).toBeTruthy();
  })
  it('setproduct to be false',()=>{
    expect(component.setProduct(value)).toBeFalsy();
  })
  it('delete item to be true',()=>{
    expect(component.DeleteItem(itemId)).toBeTruthy();
  })
  it('setproduct to be false',()=>{
    expect(component.DeleteItem(itemId)).toBeFalsy();
  })
});
