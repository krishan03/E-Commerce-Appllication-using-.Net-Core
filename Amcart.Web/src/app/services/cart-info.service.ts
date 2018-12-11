import { Injectable } from '@angular/core';
import { CartItem } from './models/cart-item';
import { CartTotal } from './models/cart-total';

@Injectable({
  providedIn: 'root'
})
export class CartInfoService {

  constructor() { }

  addItemToCart = (cartItem: CartItem) => {

  }

  getItemsTotoalCostAndCount = (): CartTotal => {
    return <CartTotal>{ Cost: 210, Count: 2 };
  }
}
