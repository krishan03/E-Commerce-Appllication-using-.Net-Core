import { Component, OnInit, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'cart-peek',
  templateUrl: './cart-peek.component.html',
  styleUrls: ['./cart-peek.component.css']
})
export class CartPeekComponent implements OnInit {

  @Input() isLoggedIn: boolean

  isUserLoggedIn: boolean

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes['isLoggedIn']) {
      this.isUserLoggedIn = this.isLoggedIn;
    }
  }

}
