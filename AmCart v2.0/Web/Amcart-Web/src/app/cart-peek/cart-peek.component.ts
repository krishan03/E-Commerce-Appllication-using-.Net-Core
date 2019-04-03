import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { CartItem } from '../models/cart-item';
import { CustomerService } from '../core/services/customer.service';

@Component({
  selector: 'cart-peek',
  templateUrl: './cart-peek.component.html',
  styleUrls: ['./cart-peek.component.css']
})
export class CartPeekComponent implements OnInit {

  @Input() isLoggedIn: boolean

  isUserLoggedIn: boolean
  context: any
  cartItems: any[]
  totalPrice: number
  totalQty: number

  constructor(private customerService: CustomerService) {
  }

  ngOnInit() {
    this.customerService.totalPrice.subscribe(price => {
      this.totalPrice = price;
    })

    this.customerService.cart.subscribe(updatedCartItems => {
      this.cartItems = updatedCartItems;
      this.totalQty = 0;
      this.cartItems.forEach(c => {
        this.totalQty+= c.quantity
      });
    })
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes['isLoggedIn']) {
      this.isUserLoggedIn = this.isLoggedIn;
      if(this.isLoggedIn){
        this.customerService.loadCustomerContext().subscribe(result => {
          this.context = result.data;
          this.cartItems = this.context.customer.cart;
          this.totalPrice = 0;
          this.totalQty = 0;
          this.cartItems.forEach(c => {
            this.totalQty+= c.quantity
            this.totalPrice+= c.product.price*c.quantity
          });

          if(this.totalPrice < 2000) {
            this.totalPrice += 100;
          }
        })
      }
    }
  }

}
