import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../core/services/customer.service';
import { User } from 'oidc-client';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  loggedInUser: User
  context: any
  cartItemLength: number

  isProfileOpen: boolean
  isWishlistOpen: boolean
  isOrderHistoryOpen: boolean

  constructor(private authService: AuthService, private customerService: CustomerService, private router: Router) {
  }

  ngOnInit() {
    this.isProfileOpen = true;
    this.isWishlistOpen = false;
    this.isOrderHistoryOpen = false;

    this.authService.getUserDetails().then(user => this.loggedInUser = user);
    this.customerService.loadCustomerContext().subscribe(result => {
      if (result.isSuccess) {
        this.context = result.data;
        this.cartItemLength = 0;
        this.context.customer.cart.forEach(item => {
          this.cartItemLength += item.quantity;
        });
        console.log(this.context);
      }
    }, error => console.log(error));;
  }

  openProfile() {
    this.isProfileOpen = true;
    this.isWishlistOpen = this.isOrderHistoryOpen = false;
  }

  openWishlist() {
    this.isWishlistOpen = true;
    this.isProfileOpen = this.isOrderHistoryOpen = false;
  }

  openOrderHistory() {
    this.isOrderHistoryOpen = true;
    this.isProfileOpen = this.isWishlistOpen = false;
  }

  navigateToCart() {
    this.router.navigate(['cart']);
  }
}
