import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { HttpService } from '../core/services/http.service';
import { Constants } from '../app-settings';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  categories: Array<any>;
  dynamicCategories: Array<any>;

  selectedCategories: Array<any>;
  additionalCategories: Array<any>;
  selectedDynamicCategories: Array<any>;
  shortDesc: string;
  longDesc: string;
  colors: Array<any>;
  size: Array<any>;
  quantity: number;
  price: number;
  name: string;


  constructor(private http: HttpService, private router: Router) {
    let categories = ['Men', 'Women', 'T-shirt', 'Shirt', 'Autumn Jackets', 'Winter Jackets', 'Leather Jackets'
      , 'Jumper & Cardgians', , 'Wallets', 'Belts', 'Glasses', 'Casual Shoes', 'Sports Shoes', 'Formal Shoes', 'Sneakers', 'Jeans',
      'Bags', 'Beauty', 'Fashion Jewellery', 'Polo', 'Adidas', 'Diesel'];

    this.categories = [];
    for (let a = 0; a < categories.length; a++) {
      this.categories.push({ label: categories[a], value: categories[a] });
    }
    console.log(this.categories);

    let dynamicCategories = ['RecentlyAdded', 'Popular', 'OnDiscount10', 'OnDiscount30', 'Bestseller'];
    this.dynamicCategories = [];
    for (let a = 0; a < dynamicCategories.length; a++) {
      this.dynamicCategories.push({ label: dynamicCategories[a], value: dynamicCategories[a] });
    }
  }

  ngOnInit() {
  }

  submitForm() {
    var cat = this.additionalCategories.length > 0 ?
      this.selectedCategories.join('|') + '|' + this.additionalCategories.join('|')
      : this.selectedCategories.join('|');
    var newProduct = {
      Name: this.name,
      Price: this.price,
      ShortDescription: this.shortDesc,
      LongDescription: this.longDesc,
      Categories: [cat],
      DynamicCategories: [this.selectedDynamicCategories.join('|')],
      TagGroups: [{ Name: "Size", Tags: this.size }, { Name: 'Colour', Tags: this.colors }],
      Quantity: this.quantity
    }
    this.http.Post(`${Constants.AppConstants.productApiRoot}Product`, newProduct).subscribe((resp) => {
      this.router.navigate(['/']);
    });
  }

}
