import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { Router } from '@angular/router';
import { CartItem } from '../models/cart-item';
import { User } from 'oidc-client';
import { ProductElasticSearchService } from '../core/services/product-elasticsearch.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userDetails: User;

  constructor(private authService: AuthService, private router: Router, private _pes: ProductElasticSearchService) { }

  ngOnInit() {
    this.authService.getUserDetails().then(user => {
      this.userDetails = user;
      console.log(this.userDetails);
    });
  }

  login() {
    this.authService.redirectToLogin();
  }

  logout() {
    this.authService.redirectToLogout();
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }

  navigateToProfile() {
    this.router.navigate(['profile']);
  }

  searchProducts(event) {
    this._pes.updateSearchText(event.target.value);
    localStorage.setItem('search', event.target.value);
    this.router.navigate(['search']);
  }

}
