import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product-item';
import { ProductService } from 'src/app/core/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  @Input() products: Array<Product>;

  constructor(private _productService: ProductService) { }

  ngOnInit() {
    this.products = [];
    this._productService.getNewArrivedProducts().subscribe((productList: Array<any>) => {
      if (productList)
        this.products = productList['Data'];
    });
  }

}