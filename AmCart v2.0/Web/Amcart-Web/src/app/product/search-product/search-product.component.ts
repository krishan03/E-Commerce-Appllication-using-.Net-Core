import { Component, OnInit, Input } from '@angular/core';
import { ProductElasticSearchService } from 'src/app/core/services/product-elasticsearch.service';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit {

  @Input() searchText:string;
  products: any[] = [];
  pageInfo: {
    from: number;
    to: number;
    total: number;
  };

  constructor(private _pes: ProductElasticSearchService) { }

  ngOnInit() {
    console.log(this._pes.isAvailable());
    this.search('women', 0, 8);
  }

  public search(searchText, from, size) {
    this._pes.FullTextSearch(searchText, from, size).then(response => {
      debugger;
      this.pageInfo = {
        from: from + 1,
        to: from + response.hits.hits.length,
        total: response.hits.total
      };
      let items = response.hits.hits;
      for (let i = 0; i < items.length; i++) {
        this.products.push({
          id: items[i]._id,
          Categories: items[i]._source.Categories[0],
          DynamicCategories: items[i]._source.DynamicCategories,
          ImageUrl: items[i]._source.ImageUrl,
          LongDescription: items[i]._source.LongDescription,
          Name: items[i]._source.Name,
          Price: items[i]._source.Price,
          Rating: items[i]._source.Rating,
          ShortDescription: items[i]._source.ShortDescription
        });
      }
      console.log(this.products);
    });
  }

  public paginate(pageNo){
    this.search(this.search, (this.pageInfo.from+1) * pageNo, 8);
  }


}
