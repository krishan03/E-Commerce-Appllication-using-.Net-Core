import { Component, OnInit } from '@angular/core';
import { ProductItem } from 'src/app/services/models/product-item';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  product: ProductItem

  constructor() { }

  ngOnInit() {
    this.product = <ProductItem>{
      Name: 'Name',
      Label: 'Label',
      NewCost: 100,
      OldCost: 120,
      Rating: 4
    };
  }

}
