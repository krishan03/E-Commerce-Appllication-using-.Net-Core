import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { CustomerService } from '../../core/services/customer.service';
import { toDate } from '@angular/common/src/i18n/format_date';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  isUserLoggedIn: boolean
  context: any
  cartItems: any[]
  totalPrice: number
  shippingPrice: number

  constructor(private customerService: CustomerService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.isUserLoggedIn = this.authService.isLoggedIn();
    if(this.isUserLoggedIn){
      this.customerService.loadCustomerContext().subscribe(response => {
        this.context = response.data;
        this.cartItems = this.context.customer.cart;
        this.totalPrice = 0;
        this.cartItems.forEach(ci => this.totalPrice += ci.product.price * ci.quantity);
        this.shippingPrice = this.totalPrice >= 2000 ? 0 : 100;
      })
    }
  }

  addQuantity(item: any){
    var cartItem = this.cartItems.find(ci => ci.id == item.id);
    var cartItemIndex = this.cartItems.indexOf(cartItem);
    if(cartItemIndex > -1) {
      this.cartItems[cartItemIndex].quantity += 1;
      this.totalPrice = 0;
      this.cartItems.forEach(ci => this.totalPrice += ci.product.price * ci.quantity);
      this.shippingPrice = this.totalPrice >= 2000 ? 0 : 100;
      this.customerService.updateCart(this.cartItems);
      this.customerService.updateTotalPrice(this.totalPrice + this.shippingPrice);
    }
  }

  subtractQuantity(item: any) {
    var cartItem = this.cartItems.find(ci => ci.id == item.id);
    var cartItemIndex = this.cartItems.indexOf(cartItem);
    if(cartItemIndex > -1 && this.cartItems[cartItemIndex].quantity > 0) {
      this.cartItems[cartItemIndex].quantity -= 1;
      this.totalPrice = 0;
      this.cartItems.forEach(ci => this.totalPrice += ci.product.price * ci.quantity);
      this.shippingPrice = this.totalPrice >= 2000 ? 0 : 100;
      this.customerService.updateCart(this.cartItems);
      this.customerService.updateTotalPrice(this.totalPrice + this.shippingPrice);
    }
  }

  proceedToCheckout() {
    this.router.navigate(['checkout']);
  }
}
