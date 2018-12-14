import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductCaptionComponent } from './product-caption/product-caption.component';
import { ProductItemComponent } from './product-item/product-item.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    ProductListComponent, 
    ProductCaptionComponent, 
    ProductItemComponent
  ],
  exports: [
    ProductListComponent
  ],
  bootstrap: [
    ProductListComponent
  ]
})
export class ProductModule { }
