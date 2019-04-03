import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-product-caption',
  templateUrl: './product-caption.component.html',
  styleUrls: ['./product-caption.component.css']
})
export class ProductCaptionComponent implements OnInit {

  @Input("id") productId:string;
  constructor() { }

  ngOnInit() {
  }

}
