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
    addedInCart: BehaviorSubject<any>

    constructor(private httpService: HttpService) {
        this.cart = new BehaviorSubject<Array<any>>([]);
        this.addedInCart = new BehaviorSubject<Array<any>>(null);
        this.totalPrice = new BehaviorSubject<number>(0);
    }

    loadCustomerContext() : Observable<OperationResult<CustomerContext>> {
        return this.httpService.Get<OperationResult<CustomerContext>>(`${Constants.AppConstants.customerApiRoot}customer/context`);
        
    }

    getCustomer() {
        return this.customerContext && this.customerContext.Customer ? this.customerContext.Customer : null;
    }

    addInWishlist(value: any) {
        var itemToAdd: any = {
            id: value.Id,
            imageUrl: value.ImageUrl,
            inStock: false,
            isActive: value.IsActive,
            name: value.Name,
            price: value.Price,
            shortDescription: value.ShortDescription,
            tagGroups: value.TagGroups
        }
        this.httpService.Post(`${Constants.AppConstants.customerApiRoot}customer/wishlist`, itemToAdd).subscribe(data => {});
    }

    addInCart(value: any, quantity: number) {
        var itemToAdd: any = {
            dynamicCategories: value.DynamicCategories,
            isActive: value.IsActive,
            quantity: quantity,
            product: {
                id: value.Id,
                imageUrl: value.ImageUrl,
                inStock: value.InStock,
                isActive: value.IsActive,
                name: value.Name,
                price: value.Price,
                shortDescription: value.ShortDescription,
                tagGroups: value.TagGroups
            }
        }
        this.httpService.Post(`${Constants.AppConstants.customerApiRoot}customer/cart`, itemToAdd).subscribe(data => {
            this.addedInCart.next(itemToAdd);
        });
    }

    updateCart(value: any[]) {
        this.cart.next(value);
    }

    updateTotalPrice(value: number) {
        this.totalPrice.next(value);
    }
}