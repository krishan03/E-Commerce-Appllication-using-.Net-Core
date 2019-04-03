import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductCaptionComponent } from './product-caption/product-caption.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { RouterModule } from '@angular/router';
import { ProductElasticSearchService } from '../core/services/product-elasticsearch.service';
import { SearchProductComponent } from './search-product/search-product.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  declarations: [
    ProductListComponent,
    ProductCaptionComponent,
    ProductItemComponent,
    ProductDetailComponent,
    SearchProductComponent
  ],
  providers: [ProductElasticSearchService],
  exports: [
    ProductListComponent,
    ProductDetailComponent
  ],
  bootstrap: [
    ProductListComponent
  ]
})
export class ProductModule { }
