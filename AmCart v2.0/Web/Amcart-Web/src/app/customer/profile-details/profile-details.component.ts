import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { CustomerContext } from '../../models/customer-context';
import { User } from 'oidc-client';
import { CustomerAddress } from '../../models/customer-address';

@Component({
  selector: 'profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.css']
})
export class ProfileDetailsComponent implements OnInit {

  @Input() customerContextData: any
  @Input() loggedInUserData: User

  context: any
  loggedInUser: User
  billingAddress: CustomerAddress

  constructor() { }

  ngOnInit() {
  }
  
  ngOnChanges(changes: SimpleChanges) {
    if(changes['loggedInUserData']) {
      this.loggedInUser = this.loggedInUserData;
    }
    if(changes['customerContextData']) {
      if(this.customerContextData){
        this.context = this.customerContextData;
        this.billingAddress = this.context.customer.addresses.find(a => a.isDefault);
      }
    }
  }

}
