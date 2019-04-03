import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { Product } from '../../models/product-item';

@Component({
  selector: 'wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  @Input() customerContextData: any

  context: any
  wishlistItems: any[]

  constructor() { }

  ngOnInit() {
  }
  
  ngOnChanges(changes: SimpleChanges) {
    if(changes['customerContextData']) {
      this.context = this.customerContextData;
      this.wishlistItems = this.context.customer.wishlist;
    }
  }

}
