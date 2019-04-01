import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { CartItem } from '../models/cart-item';

@Component({
  selector: 'cart-peek',
  templateUrl: './cart-peek.component.html',
  styleUrls: ['./cart-peek.component.css']
})
export class CartPeekComponent implements OnInit {

  @Input() isLoggedIn: boolean

  isUserLoggedIn: boolean
  cartItems: CartItem[]
  totalPrice: number

  constructor() {
    this.totalPrice = 0;
    this.cartItems = [];
  }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes['isLoggedIn']) {
      this.isUserLoggedIn = this.isLoggedIn;
    }
  }

}
