import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../core/services/customer.service';
import { AuthService } from '../../core/services/auth.service';
import { CONTEXT } from '@angular/core/src/render3/interfaces/view';
import { User } from 'oidc-client';
import { OrderService } from '../../core/services/order-service';
import { Router } from '@angular/router';
import { CustomerAddress } from '../../models/customer-address';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  context: any
  userDetails: User
  cartItems: any[]
  totalPrice: number
  shippingPrice: number
  shippingAddress: any

  paymentMethod: string
  shippingMethod: string
  orderNotes: string

  constructor(private authService: AuthService, private customerService: CustomerService, private orderService: OrderService, private router: Router) {
    this.paymentMethod = 'Transfer';
    this.shippingMethod = 'Airplane';
  }

  ngOnInit() {
    if(this.authService.isLoggedIn()){
      this.authService.getUserDetails().then(details => {
        this.userDetails = details;
      })
      this.customerService.loadCustomerContext().subscribe(response => {
        if(response != null){
          this.context = response.data;
          this.cartItems = this.context.customer.cart;
          this.totalPrice = 0;
          this.cartItems.forEach(ci => this.totalPrice += ci.product.price * ci.quantity);
          this.shippingPrice = this.totalPrice >= 2000 ? 0 : 100;
          this.shippingAddress = this.context.customer.addresses.find(a => a.isDefault);
          if(!this.shippingAddress){
            this.shippingAddress = {
              companyName: "",
              name: "",
              pincode: "",
              state: "",
              email: "",
              houseStreetNumber: "",
              locality: "",
              city: "",
              country: "",
              isDefault: true
            };
          }
          else{
            this.shippingAddress.email = "";
          }
        }
      })
    }
  }

  updateShippingMethod(shippingMethod: string){
    this.shippingMethod = shippingMethod;
  }

  updatePaymentMethod(paymentMethod: string) {
    this.paymentMethod = paymentMethod;
  }

  placeOrder() {
    var orderDetails: any = {
      customerId: this.context.customer.id,
      deliveryAddress: this.shippingAddress,
      paymentType: this.paymentMethod,
      status: [{
        statusType: "Ordered"
      }],
      trackingNumber: "hifyuw4huiweudy23d9edy928",
      orderedProducts: this.cartItems.map(i => {
        return {
          id: i.product.id,
          name: i.product.name,
          shortDescription: i.product.shortDescription,
          price: i.product.price,
          tagGroups: i.product.tagGroups,
          dynamicCategories: i.dynamicCategories,
          quantity: i.quantity,
          imageUrl: i.product.imageUrl
        }
      }),
      totalAmountPayable: this.totalPrice + this.shippingPrice,
      taxPercentage: 0,
      userId: this.userDetails.profile.sub
    };
    console.log(orderDetails);
    this.orderService.placeOrder(orderDetails).subscribe(response => {
      console.log(response);
      this.customerService.updateCart([]);
      this.customerService.updateTotalPrice(0);
      this.router.navigate(['orderDetails/' + response.Data.Id]);
    });
  }
}
