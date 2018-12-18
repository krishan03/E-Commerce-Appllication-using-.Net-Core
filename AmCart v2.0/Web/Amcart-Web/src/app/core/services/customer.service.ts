import { Injectable } from "@angular/core";
import { CustomerContext } from "src/app/models/customer-context";
import { HttpService } from "./http.service";
import { Constants } from "src/app/app-settings";
import { OperationResult } from "src/app/models/operation-result";

@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    baseUrl = Constants.AppConstants.customerApiRoot;
    customerContext: CustomerContext

    constructor(private httpService: HttpService) { }

    loadCustomerContext() {
        this.httpService.Get<OperationResult<CustomerContext>>(`${Constants.AppConstants.customerApiRoot}customer/context`)
        .subscribe(result => {
            if(result.isSuccess) {
                this.customerContext = result.data;
            }
        }, error => console.log(error));
    }

    getCustomer() {
        return this.customerContext && this.customerContext.Customer ? this.customerContext.Customer : null;
    }
}