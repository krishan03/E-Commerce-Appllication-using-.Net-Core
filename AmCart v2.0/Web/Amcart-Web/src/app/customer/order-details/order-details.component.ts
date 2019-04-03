import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from '../../core/services/order-service';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  orderId: string
  orderDetails: any
  totalPrice: number
  shippingPrice: number
  userDetails: any

  constructor(private route: ActivatedRoute, private orderService: OrderService, private authService: AuthService) { 
    this.route.paramMap.subscribe(params => {
      this.orderId = params.get("id");
      this.authService.getUserDetails().then(details => {
        this.userDetails = details;
        console.log(this.userDetails);
      })
      this.orderService.getOrderDetails(this.orderId)
        .subscribe((order: any) => {
          if (order) {
            this.orderDetails = order.Data;
            this.totalPrice = this.shippingPrice = 0;
            this.orderDetails.OrderedProducts.forEach(p => {
              this.totalPrice += p.Price;
            });

            if(this.totalPrice < 2000){
              this.shippingPrice = 100;
            }
          }
        });
    })
  }

  ngOnInit() {
  }

}
