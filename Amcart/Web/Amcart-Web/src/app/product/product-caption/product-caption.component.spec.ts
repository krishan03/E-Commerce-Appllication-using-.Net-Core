import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCaptionComponent } from './product-caption.component';

describe('ProductCaptionComponent', () => {
  let component: ProductCaptionComponent;
  let fixture: ComponentFixture<ProductCaptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductCaptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductCaptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
