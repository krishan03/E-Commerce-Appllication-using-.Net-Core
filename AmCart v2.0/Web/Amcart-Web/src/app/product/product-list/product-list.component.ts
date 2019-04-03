import { Component, OnInit, Input, OnDestroy, SimpleChanges } from '@angular/core';
import { Subject } from 'rxjs';
import { Product } from '../../models/product-item';
import { ProductElasticSearchService } from 'src/app/core/services/product-elasticsearch.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit, OnDestroy {

  @Input() data: Array<Product>;

  products: Product[]
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private productService: ProductElasticSearchService) { }

  ngOnInit() {
    console.log(this.productService.isAvailable());
  }

  ngOnChanges(changes: SimpleChanges) {

    if (changes['data']) {
      this.products = this.data;
    }
  }

  ngOnDestroy(): void {
    this.destroy$.next(true);
    this.destroy$.unsubscribe();
  }

}
