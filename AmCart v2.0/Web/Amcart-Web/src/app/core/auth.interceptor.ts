import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { AuthService } from "./services/auth.service";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { Constants } from "../app-settings";
import 'rxjs/operators';
import { tap } from 'rxjs/internal/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    
    constructor(private authService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(request.url.startsWith(Constants.AppConstants.customerApiRoot) || request.url.startsWith(Constants.AppConstants.orderApiRoot)) {
            let accessToken = this.authService.getAccessToken();
            if(accessToken != '') {
                let headers = new HttpHeaders({
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${accessToken}`
                });
                let requestWithHeaders = request.clone({ headers: headers });
                return next.handle(requestWithHeaders);
            }
            else{
                return next.handle(request);
            }
        }

        return next.handle(request);
        // .pipe(tap(() => {}, error => {
        //     var response = error as HttpErrorResponse;
        //     if(response && (response.status == 401 || response.status == 403))
        //     {
        //         // Redirect to unauthorized screen.
        //     }
        // }));
    }
}