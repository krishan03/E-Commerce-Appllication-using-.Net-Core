import { Injectable } from "@angular/core";
import { CustomerContext } from "src/app/models/customer-context";
import { HttpService } from "./http.service";
import { Constants } from "src/app/app-settings";

@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    baseUrl = Constants.AppConstants.customerApiRoot;
    customerContext: CustomerContext

    constructor(private httpService: HttpService) { }

    loadCustomerContext() {
        this.httpService.Get<CustomerContext>(`${Constants.AppConstants.customerApiRoot}customer/context`)
        .subscribe(context => {
            this.customerContext = context;
        }, error => console.log(error));
    }
}