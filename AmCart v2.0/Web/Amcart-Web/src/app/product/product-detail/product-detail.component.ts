import { Component, OnInit } from '@angular/core';
import { ProductDetails } from 'src/app/models/product-details';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/core/services/product.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

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

  constructor(private route: ActivatedRoute, private productService: ProductService) {
    this.sizeMap = new Map([['XL', 2], ['L', 2]]);
    this.colorMap = new Map([['Red', 2], ['blue', 2]]);
    this.selectedColor = "White";
    this.selectedSize = "XL";
    this.Availability = false;

    // this.productDetails =
    //   <ProductDetails>{
    //     Name: 'Footwear 1',
    //     NewCost: 3000,
    //     OldCost: 6000,
    //     ProductCode: '156834',
    //     ProductTags: 'Clother, Fashion',
    //     Category: 'Mens Wear',
    //     Description: 'Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.',
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Rating: 2,
    //     ColorSizeMap: new Map([
    //       ['White', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Blue', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Orange', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Cherry', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Peach', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Yellow', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Pink', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])],
    //       ['Lime', new Map([['XL', 1], ['L', 2], ['M', 0], ['XS', 0], ['S', 3]])]]),

    //     //ColorMap:new Map([['Peach',2], ['Blue',2],['Orange',2],['Cherry',2]]),
    //     //SizeMap:new Map([['XL',2], ['L',2]]),
    //     InfoList: ["100% Cotton", "Sit just below waist", "Dry Clean", "50% Elastomultiester", "Slim fit throught", "Machine Wash Warm"]
    //   }

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
}
