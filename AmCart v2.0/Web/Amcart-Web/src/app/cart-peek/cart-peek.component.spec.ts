import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartPeekComponent } from './cart-peek.component';

describe('CartPeekComponent', () => {
  let component: CartPeekComponent;
  let fixture: ComponentFixture<CartPeekComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartPeekComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartPeekComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
