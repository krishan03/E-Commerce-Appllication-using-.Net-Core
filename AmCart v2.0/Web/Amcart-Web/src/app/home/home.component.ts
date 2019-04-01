import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ProductService } from '../core/services/product.service';
import { Observable } from 'rxjs';
import { Product } from '../models/product-item';
import { APIResponse } from '../models/response';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  newArrivedProducts: Product[]
  specialProducts: Product[]
  bestSellingProducts: Product[]

  constructor(private productService: ProductService, private ref: ChangeDetectorRef) {
    this.newArrivedProducts = [];
    this.specialProducts = [];
    this.bestSellingProducts = [];
  }

  ngOnInit() {
    this.getNewArrivedProducts().subscribe(products => 
      {
        this.newArrivedProducts = products.Data;
        this.ref.markForCheck();
      });
      this.getSpecialProducts().subscribe(products => {
        this.specialProducts = products.Data;
        this.ref.markForCheck();
      });
      this.getBestsellingProducts().subscribe(products =>{
        this.bestSellingProducts = products.Data;
        this.ref.markForCheck();
      });
  }

  getNewArrivedProducts(): Observable<APIResponse> {
    return this.productService.getNewArrivedProducts();
  }

  getSpecialProducts(): Observable<APIResponse> {
    return this.productService.getSpecialProducts();
  }

  getBestsellingProducts(): Observable<APIResponse> {
    return this.productService.getBestsellingProducts();
  }
}
