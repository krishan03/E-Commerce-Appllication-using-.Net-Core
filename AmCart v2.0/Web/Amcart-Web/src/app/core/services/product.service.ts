import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { Constants } from "src/app/app-settings";
import { APIResponse } from "../../models/response";

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    
    baseUrl: string = Constants.AppConstants.productApiRoot;

    constructor(private httpService: HttpService){ }

    public getNewArrivedProducts(): Observable<APIResponse> {
        let url = this.baseUrl + 'product/new';
        return this.httpService.Get<APIResponse>(url);
    }
    
    public getSpecialProducts(): Observable<APIResponse> {
        let url = this.baseUrl + 'product/popular';
        return this.httpService.Get<APIResponse>(url);
    }
    
    public getBestsellingProducts(): Observable<APIResponse> {
        let url = this.baseUrl + 'product/bestseller';
        return this.httpService.Get<APIResponse>(url);
    }
}