import * as elasticsearch from 'elasticsearch-browser';
import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root'
})
export class ProductElasticSearchService {
    private client: elasticsearch.Client

    constructor(private _http: HttpService) {
        if (!this.client) {
            this.connect();
        }
    }

    private connect() {
        this.client = new elasticsearch.Client({
            host: 'http://137.117.243.164:9200',
            log: 'trace'
        });
    }

    public Ping() {
        this.client.ping({
            requestTimeout: Infinity,
            body: 'hello amcart!'
        });
    }

    public isAvailable(): any {
        return this.client.ping({
            requestTimeout: Infinity,
            body: 'hello AMCART_ !'
        });
    }

    public FullTextSearch(searchText, from, size): any {
        let query = `{
            "from":${from},
            "size":${size},
        "query": {
          "bool": {
            "should": [
              {
                "match": {
                  "Name": {
                    "query": "${searchText}",
                    "analyzer": "standard",
                    "fuzziness": 1,
                    "boost": 2
                  }
                }
              }      ]
          }
        }
      }
      `;

        let result = this.client.search({ body: query });
        debugger;
        return result;
    }

}