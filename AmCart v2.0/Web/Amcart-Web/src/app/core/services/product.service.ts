import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { Product } from "src/app/models/product-item";
import { Constants } from "src/app/app-settings";

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    
    baseUrl: string = Constants.AppConstants.productApiRoot;

    constructor(private httpService: HttpService){ }

    public getNewArrivedProducts(): Observable<any> {
        let url = this.baseUrl + 'product/new';
        return this.httpService.Get<any>(url);
    }
    
    public getSpecialProducts(): Observable<Array<Product>> {
        let url = this.baseUrl + 'product/popular';
        return this.httpService.Get<Array<Product>>(url);
    }
    
    public getBestsellingProducts(): Observable<Array<Product>> {
        let url = this.baseUrl + 'product/bestseller';
        return this.httpService.Get<Array<Product>>(url);
    }
}