import { Injectable } from '@angular/core';
import { AppSettings } from '../app-settings';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private baseUrl: string = AppSettings.API_ENDPOINT;

  constructor(private httpClient: HttpClient) { }
  
  Get<T>(url: string): Observable<T> {
    url = this.baseUrl + url;
    return this.httpClient.get(url).pipe(map((response: T) => { return response; }));
  }

  Post(url: string, body: any): Observable<any> {
    url = this.baseUrl + url;
    let headers = new HttpHeaders();
    headers.append('content-type', 'false');
    headers.append('crossDomain', 'true');
    headers.append('processData', 'false');
    return this.httpClient.post(url, body, { headers: headers }).pipe(map((response: Response) => { return response; }));
  }

  Delete(url: string): Observable<any> {
    url = this.baseUrl + url;
    return this.httpClient.delete(url);
  }
}
