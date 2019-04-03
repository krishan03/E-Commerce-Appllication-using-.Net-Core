import { Injectable } from "@angular/core";
import { CustomerContext } from "../../models/customer-context";
import { HttpService } from "./http.service";
import { Constants } from "../../app-settings";
import { OperationResult } from "../../models/operation-result";
import { Observable, BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    baseUrl = Constants.AppConstants.customerApiRoot;
    customerContext: CustomerContext

    totalPrice: BehaviorSubject<number>
    cart: BehaviorSubject<Array<any>>

    constructor(private httpService: HttpService) {
        this.cart = new BehaviorSubject<Array<any>>([]);
        this.totalPrice = new BehaviorSubject<number>(0);
    }

    loadCustomerContext() : Observable<OperationResult<CustomerContext>> {
        return this.httpService.Get<OperationResult<CustomerContext>>(`${Constants.AppConstants.customerApiRoot}customer/context`);
        
    }

    getCustomer() {
        return this.customerContext && this.customerContext.Customer ? this.customerContext.Customer : null;
    }

    updateCart(value: any[]) {
        this.cart.next(value);
    }

    updateTotalPrice(value: number) {
        this.totalPrice.next(value);
    }
}