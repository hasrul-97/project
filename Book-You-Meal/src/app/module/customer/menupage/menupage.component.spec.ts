import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MenupageComponent } from './menupage.component';
import {  FormsModule, ReactiveFormsModule } from '../../../../../node_modules/@angular/forms';
import { ItemFilterPipe } from '../../../shared/pipes/item-filter.pipe';
import { RouterTestingModule } from '../../../../../node_modules/@angular/router/testing';
import { HttpClientTestingModule } from '../../../../../node_modules/@angular/common/http/testing';

describe('MenupageComponent', () => {
  let component: MenupageComponent;
  let fixture: ComponentFixture<MenupageComponent>;
  var type;
  var category;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenupageComponent,ItemFilterPipe],
      imports:[FormsModule,ReactiveFormsModule,RouterTestingModule,HttpClientTestingModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenupageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('bookmarked to be true',()=>{
    expect(component.bookmarked()).toBeTruthy();
  })
  it('bookmarked to be false',()=>{
    expect(component.bookmarked()).toBeFalsy();
  })
  it('checkflag to be true',()=>{
    expect(component.checkFlag()).toBeTruthy();
  })
  it('checkflag to be false',()=>{
    expect(component.checkFlag()).toBeFalsy();
  })
  it('selected to be true',()=>{
    expect(component.Selectedtype(type)).toBeTruthy();
  })
  it('selected to be false',()=>{
    expect(component.Selectedtype(type)).toBeFalsy();
  })
  it('selected to be true',()=>{
    expect(component.SelectedCategory(category)).toBeTruthy();
  })
  it('selected to be false',()=>{
    expect(component.SelectedCategory(category)).toBeFalsy();
  })
  it('bookmarked restaurnt to be true',()=>{
    expect(component.bookmarkRestaurant()).toBeTruthy();
  })
  it('bookmarked restaurant to be false',()=>{
    expect(component.bookmarkRestaurant()).toBeFalsy();
  })
  it('remove bookmark to be true',()=>{
    expect(component.RemoveBookmark()).toBeTruthy();
  })
  it('remove bookmark to be false',()=>{
    expect(component.RemoveBookmark()).toBeFalsy();
  })
  it('filter to be true',()=>{
    expect(component.FilterItems()).toBeTruthy();
  })
  it('filter  to be false',()=>{
    expect(component.FilterItems()).toBeFalsy();
  })
  it('new search to be true',()=>{
    expect(component.newSearch()).toBeTruthy();
  })
  it('new search  to be false',()=>{
    expect(component.newSearch()).toBeFalsy();
  })

});
