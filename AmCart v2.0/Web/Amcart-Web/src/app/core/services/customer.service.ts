import { Injectable } from "@angular/core";
import { CustomerContext } from "../../models/customer-context";
import { HttpService } from "./http.service";
import { Constants } from "../../app-settings";
import { OperationResult } from "../../models/operation-result";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    baseUrl = Constants.AppConstants.customerApiRoot;
    customerContext: CustomerContext

    constructor(private httpService: HttpService) { }

    loadCustomerContext() : Observable<OperationResult<CustomerContext>> {
        return this.httpService.Get<OperationResult<CustomerContext>>(`${Constants.AppConstants.customerApiRoot}customer/context`);
        
    }

    getCustomer() {
        return this.customerContext && this.customerContext.Customer ? this.customerContext.Customer : null;
    }
}