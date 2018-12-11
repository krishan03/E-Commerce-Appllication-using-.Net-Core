import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListingComponent } from './product-listing/product-listing.component';
import { ProductListItemComponent } from './product-list-item/product-list-item.component';
import { ProductCaptionComponent } from './product-caption/product-caption.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ProductCaptionComponent,
    ProductListItemComponent,
    ProductListingComponent],
  exports: [ProductListingComponent],
  bootstrap: [ProductListingComponent]
})
export class ProductListingModule { }
