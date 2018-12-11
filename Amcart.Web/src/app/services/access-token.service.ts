import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { LocalStorageService } from './local-storage.service';

@Injectable({
    providedIn: 'root'
})
export class AccessTokenService {

    private _baseUrl: string = "http://localhost:5000/connect/token"

    constructor(private _httpClient: HttpClient, private _localStorageService: LocalStorageService) { }

    GetToken(user: any) {
        // var data = "grant_type=password&username=" + user.userName + "&password=" + user.password + "&client_id=client";
        let data = `grant_type=password&client_id=client&client_secret=secret&username=${user.userName}&password=${user.password}`;
        debugger;
        let headers = new HttpHeaders({
            'Content-Type': 'application/x-www-form-urlencoded'
        });
        let requestOption = { headers: headers };

        return this._httpClient.post(this._baseUrl, data, requestOption)
            .pipe(map((response: Response) => {
                this._localStorageService.setItem({ key: "access-token", value: JSON.stringify(response) });
                return true;
            }));
            // .catch((err: any) => {
            // });
    }

}