import { Component, OnInit, SimpleChanges, Input } from '@angular/core';
import { User } from 'oidc-client';
import { OrderService } from 'src/app/core/services/order-service';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  @Input() customerContextData: any
  @Input() loggedInUserData: User

  context: any
  loggedInUser: User
  orders: any[]

  constructor(private orderService: OrderService) { }

  ngOnInit() {
  }
  
  ngOnChanges(changes: SimpleChanges) {
    if(changes['loggedInUserData']) {
      this.loggedInUser = this.loggedInUserData;
    }
    if(changes['customerContextData']) {
      if(this.customerContextData){
        this.context = this.customerContextData;
        this.orderService.getOrders().subscribe(response => {
          this.orders = response.Data;
          console.log(this.orders);
        })
      }
    }
  }

}
