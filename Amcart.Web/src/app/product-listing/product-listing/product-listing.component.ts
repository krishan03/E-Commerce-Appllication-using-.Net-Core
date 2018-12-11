import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ProductItem } from '../../services/models/product-item';
import { Observable, Subject } from 'rxjs';
import { HttpServiceService } from 'src/app/services/http-service/http-service.service';
import { Urls } from 'src/app/appsettings';

@Component({
  selector: 'product-listing',
  templateUrl: './product-listing.component.html',
  styleUrls: ['./product-listing.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ProductListingComponent implements OnInit {
  // products: ProductItem[];//"url","lable",5000,4000,"Footware Type 1",5),
  products$: Subject<ProductItem[]> = new Subject<ProductItem[]>();
  constructor(private _http: HttpServiceService) {
    // this.products = [
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Label: 'NEW',
    //     Name: 'Pure Cotton Shirt Slim Fit',
    //     NewCost: 5000
    //   },
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Name: 'Nike Sports Shoes',
    //     NewCost: 3000,
    //     OldCost: 6000,
    //   },
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Label: 'NEW',
    //     Name: 'Lower Ipsum Text',
    //     NewCost: 5000
    //   },
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Label: 'NEW',
    //     Name: 'Lower Ipsum Text 2',
    //     NewCost: 5000
    //   },
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Label: '-20%',
    //     Name: 'Lower Ipsum Text 3',
    //     OldCost: 15000,
    //     NewCost: 5000
    //   },
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Name: 'Lower Ipsum Text 4',
    //     OldCost: 8000,
    //     NewCost: 3000
    //   },
    //   <ProductItem>{
    //     Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
    //     Label: '-50%',
    //     Name: 'Lower Ipsum Text 5',
    //     NewCost: 5000
    //   }
    // ];

  }

  ngOnInit() {
    this._http.Get(Urls.GET_PRODUCTS).subscribe((products: any[]) => {
      debugger;
      //       categories: ["Men|T-shirt|Polo"]
      // createdOnDate: "0001-01-01T00:00:00"
      // dynamicCategories: (2) ["OnDiscount30", "RecentlyAdded"]
      // id: "5c061eff14590a1d0c902602"
      // isActive: false
      // longDescription: "ax: Applicable tax on the basis of exact location & discount will be charged at the time of checkout 100% Original Products Free Delivery on order above Rs. 1199 Cash on delivery might be available Easy 30 days returns & 30 days exchanges Try & Buy might be available"
      // modifiedOnDate: "2018-12-04T10:10:19.9602348Z"
      // name: "Polo T-shirt"
      // price: 2499
      // shortDescription: "Men Navy Blue Printed Polo T-shirt"
      // tagGroups:
      let productsToDisplay = [];
      if (products) {
        for (let product of products) {
          productsToDisplay.push(<ProductItem>{
            Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
            Name: product['shortDescription'],
            NewCost: product['price']
          });
        }
        debugger;
        this.products$.next(productsToDisplay)
      }
    });
  }

  previousPage(event) {
    event.preventDefault();
  }

  nextPage(event) {
    event.preventDefault();
  }

}

