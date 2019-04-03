import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Constants } from "../../app-settings";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class OrderService {

    constructor(private httpService: HttpService)
    {}
    
    placeOrder(orderDetails: any): Observable<any> {
        return this.httpService.Post(`${Constants.AppConstants.orderApiRoot}order`, orderDetails);
    }

    getOrderDetails(id: string) {
        return this.httpService.Get<any>(`${Constants.AppConstants.orderApiRoot}order/${id}`);
    }
}