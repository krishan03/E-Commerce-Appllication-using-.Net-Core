import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { Product } from 'src/app/models/product-item';
import { ProductService } from 'src/app/core/services/product.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {

  @Input() products: Array<Product>;
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private _productService: ProductService) { }

  ngOnInit() {
    this.products = [];
    this._productService.getNewArrivedProducts()
      .pipe(takeUntil(this.destroy$))
      .subscribe((productList: Array<any>) => {
        if (productList)
          this.products = productList['Data'];
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }

}