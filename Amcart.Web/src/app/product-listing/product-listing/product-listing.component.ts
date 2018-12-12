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
  }

  ngOnInit() {
    this._http.Get(Urls.GET_PRODUCTS).subscribe((products: any[]) => {
      let productsToDisplay = [];
      if (products) {
        for (let product of products) {
          productsToDisplay.push(<ProductItem>{
            Image: 'https://rukminim1.flixcart.com/image/832/832/jao8uq80/shoe/3/r/q/sm323-9-sparx-white-original-imaezvxwmp6qz6tg.jpeg?q=70',
            Name: product['shortDescription'],
            NewCost: product['price'],
            Label: '',
            OldCost: 0,
            Rating: 4
          });
        }

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