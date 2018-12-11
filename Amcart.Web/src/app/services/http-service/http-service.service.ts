import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppSettings } from 'src/app/appsettings';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {

  private _baseUrl: string = AppSettings.API_ENDPOINT;

  constructor(private _httpClient: HttpClient) { }

  GetRequest(url: string): Observable<any> {
    url = this._baseUrl + url;
    return this._httpClient.get(url).pipe(map((response: Response) => { return response; }));
  }

  Get<T>(url: string): Observable<T> {
    url = this._baseUrl + url;

    return this._httpClient.get(url)
      .pipe(map((response: T) => {
        return response;
      }));
  }

  PostRequest(url: string, body: any): Observable<any> {
    url = this._baseUrl + url;
    let headers = new HttpHeaders();
    headers.append('content-type', 'false');
    // headers.append('mimeType', 'multipart/form-data');
    headers.append('crossDomain', 'true');
    headers.append('processData', 'false');

    return this._httpClient.post(url, body, { headers: headers })
            .pipe(map((response: Response) => {
              return response;
            }));
  }

  DeleteRequest(url: string): Observable<any> {
    url = this._baseUrl + url;
    return this._httpClient.delete(url);
  }

}
