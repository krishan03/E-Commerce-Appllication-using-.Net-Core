import { Component, OnInit, Input } from '@angular/core';
import { ProductItem } from '../../services/models/product-item';

@Component({
  selector: 'product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.css']
})
export class ProductListItemComponent implements OnInit {
  @Input() product:ProductItem;
  constructor() { }

  ngOnInit() {
  }

}
