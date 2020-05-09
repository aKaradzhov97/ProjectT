import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCategoryFormComponent } from './update-category-form.component';

describe('UpdateCategoryFormComponent', () => {
  let component: UpdateCategoryFormComponent;
  let fixture: ComponentFixture<UpdateCategoryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateCategoryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateCategoryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
