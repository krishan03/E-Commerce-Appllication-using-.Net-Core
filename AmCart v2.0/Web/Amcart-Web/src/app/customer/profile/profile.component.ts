import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/core/services/customer.service';
import { Customer } from 'src/app/models/customer';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  private customer: Customer

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customer = this.customerService.getCustomer();
  }

}
