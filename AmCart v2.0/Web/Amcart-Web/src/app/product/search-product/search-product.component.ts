import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ProductElasticSearchService } from 'src/app/core/services/product-elasticsearch.service';
import { debug } from 'util';

@Component({
  selector: 'app-search-product',
  templateUrl: './search-product.component.html',
  styleUrls: ['./search-product.component.css']
})
export class SearchProductComponent implements OnInit, OnDestroy {

  @Input() searchText: string;
  products: any[] = [];
  pageInfo: {
    from: number;
    to: number;
    total: number;
  };
  productTags = {
    Men: false,
    Accessories: false,
    Clother: false,
    Shoes: false,
    Jacket: false,
    Woman: false,
    Fashion: false
  };

  constructor(private _pes: ProductElasticSearchService) { }

  ngOnInit() {
    console.log(this._pes.isAvailable());

    // let searchString = localStorage.getItem("search") ? localStorage.getItem("search") : 'women';
    // this.search('women', 0, 8);
    this._pes.searchText$.subscribe(text => {
      if (text)
        this.search(text, 0, 8);
      else
        this.search('women', 0, 8);
    });
  }

  ngOnDestroy() {
    localStorage.clear();
  }

  clearColor(event) {
    this.color = '';
    this.selectColor(event, this.color);
  }
  clearAll(event) {
    event.preventDefault();
    this.productTags.Men = false;

    this.color = '';
    this.tags = [];

    this.search('wom', 0, 8);
  }

  public search(searchText, from, size) {
    this.products = [];
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

  public paginate(pageNo) {
    this.search(this.search, (this.pageInfo.from + 1) * pageNo, 8);
  }

  color: string = '';

  public selectColor(event, color) {
    event.preventDefault();
    this.color = color;
    let queryString = this.tags.join('|');
    this.products = [];
    this._pes.Search(queryString, this.color, 0, 8).then(response => {
      this.pageInfo = {
        from: 0 + 1,
        to: 0 + response.hits.hits.length,
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

  isChecked = true;
  tags: Array<string> = [];
  public changeTag(tag) {
    let index = this.tags.findIndex(t => t == tag);
    if (index >= 0) {
      this.tags.splice(index, 1);
    } else {
      this.tags.push(tag);
    }
    let queryString = this.tags.join('|');
    this.products = [];
    this._pes.Search(queryString, this.color, 0, 8).then(response => {
      debugger;
      this.pageInfo = {
        from: 0 + 1,
        to: 0 + response.hits.hits.length,
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
}
