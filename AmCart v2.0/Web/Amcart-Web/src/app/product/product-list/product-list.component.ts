import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product-item';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  @Input() products : Array<Product>;

  constructor() { }

  ngOnInit() {
  }

}