import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }
  
  Get<T>(url: string): Observable<T> {
    return this.httpClient.get(url).pipe(map((response: T) => { return response; }));
  }

  Post(url: string, body: any): Observable<any> {
    let headers = new HttpHeaders();
    headers.append('content-type', 'false');
    headers.append('crossDomain', 'true');
    headers.append('processData', 'false');
    return this.httpClient.post(url, body, { headers: headers }).pipe(map((response: Response) => { return response; }));
  }

  Delete(url: string): Observable<any> {
    return this.httpClient.delete(url);
  }
}
