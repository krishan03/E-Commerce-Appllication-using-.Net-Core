import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../core/services/customer.service';
import { Customer } from '../../models/customer';
import { User } from 'oidc-client';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  loggedInUser: User
  private customer: Customer

  constructor(private authService: AuthService, private customerService: CustomerService) { }

  ngOnInit() {
    this.customer = this.customerService.getCustomer();
    this.authService.getUserDetails().then(user => this.loggedInUser = user);
  }

}
