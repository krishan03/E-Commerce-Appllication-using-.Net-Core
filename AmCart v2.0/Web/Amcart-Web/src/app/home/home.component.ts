import { Component, OnInit } from '@angular/core';
import { ProductService } from '../core/services/product.service';
import { Observable } from 'rxjs';
import { Product } from '../models/product-item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  featuredProducts: Array<Product>
  newArrivedProducts: Array<Product>
  specialProducts: Array<Product>
  bestSellingProducts: Array<Product>

  constructor(private productService: ProductService) {
    this.getFeaturedProducts().subscribe(products => this.featuredProducts = products);
    this.getNewArrivedProducts().subscribe(products => this.newArrivedProducts = products);
    this.getSpecialProducts().subscribe(products => this.specialProducts = products);
    this.getBestsellingProducts().subscribe(products => this.bestSellingProducts = products);
  }

  ngOnInit() {
  }

  getFeaturedProducts(): Observable<Array<Product>> {
    return this.productService.getFeaturedProducts();
  }

  getNewArrivedProducts(): Observable<Array<Product>> {
    return this.productService.getNewArrivedProducts();
  }

  getSpecialProducts(): Observable<Array<Product>> {
    return this.productService.getSpecialProducts();
  }

  getBestsellingProducts(): Observable<Array<Product>> {
    return this.productService.getFeaturedProducts();
  }
}
