import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WishedCounterComponent } from './wished-counter.component';

describe('WishedCounterComponent', () => {
  let component: WishedCounterComponent;
  let fixture: ComponentFixture<WishedCounterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WishedCounterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WishedCounterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
