import { Component, OnInit,Input } from '@angular/core';
import { Product } from '../../models/product-item';
import { CustomerService } from '../../core/services/customer.service';
import { AuthService } from '../../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-caption',
  templateUrl: './product-caption.component.html',
  styleUrls: ['./product-caption.component.css']
})
export class ProductCaptionComponent implements OnInit {

  @Input() product: any;

  constructor(private customerService: CustomerService, private authService: AuthService) { }

  ngOnInit() {
  }

  addToCart() {
    if(!this.authService.isLoggedIn()){
      this.authService.redirectToLogin();
    }
    else{
    this.customerService.addInCart(this.product);
    }
  }

  addToWishlist() {
    if(!this.authService.isLoggedIn()){
      this.authService.redirectToLogin();
    }
    else{
      this.customerService.addInCart(this.product);
    }
  }
}
