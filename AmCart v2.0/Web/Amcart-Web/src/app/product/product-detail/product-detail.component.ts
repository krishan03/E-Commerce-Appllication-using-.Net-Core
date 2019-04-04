import { Component, OnInit } from '@angular/core';
import { ProductDetails } from 'src/app/models/product-details';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/core/services/product.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CustomerService } from '../../core/services/customer.service';

@Component({
  selector: 'product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  productDetails: ProductDetails;
  sizeMap: Map<string, number>;
  colorMap: Map<string, number>;
  selectedColor: string;
  selectedSize: string;
  Availability: boolean;
  productId: string;
  availableColors: string[];
  availableSizes: string[];
  destroy$: Subject<boolean> = new Subject<boolean>();
  quantity: number

  constructor(private route: ActivatedRoute, private productService: ProductService, private customerService: CustomerService) {
    this.sizeMap = new Map([['XL', 2], ['L', 2]]);
    this.colorMap = new Map([['Red', 2], ['blue', 2]]);
    this.selectedColor = "White";
    this.selectedSize = "XL";
    this.Availability = false;
    this.quantity = 1;

    this.route.paramMap.subscribe(params => {
      this.productId = params.get("id");
      this.productService.getProductDetails(this.productId)
        .pipe(takeUntil(this.destroy$))
        .subscribe((product: any) => {
          if (product) {
            this.productDetails = product.Data;
            this.availableColors = product.Data.TagGroups.find(x => x.Name == 'Colour').Tags;
            this.availableColors = this.availableColors.map(s => s.trim());
            this.availableSizes = product.Data.TagGroups.find(x => x.Name == 'Size').Tags;
            this.availableSizes = this.availableSizes.map(s => s.trim());
            this.selectedColor = this.availableColors[0];
            this.selectedSize = this.availableSizes[0];
          }
        });
    })
  }
  ngOnInit() { }

  selectColor(event) {
    this.selectedColor = event.target.value;
  }
  selectSize(event) {
    this.selectedSize = event.target.value;
  }

  increaseQuantity() {
    this.quantity += 1;
  }

  decreaseQuantity() {
    if(this.quantity > 0){
      this.quantity -=1;
    }
  }

  addToCart() {
    this.customerService.addInCart(this.productDetails, this.quantity);
  }

  addToWishlist() {
    this.customerService.addInWishlist(this.productDetails);
  }
}
