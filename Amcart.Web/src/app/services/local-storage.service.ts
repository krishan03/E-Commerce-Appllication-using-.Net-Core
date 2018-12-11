import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class LocalStorageService {

    constructor() { }

    getItem = (itemName: string) => {
        localStorage.getItem(itemName);
    }

    setItem = (item: { key: string; value: string; }) => {
        localStorage.setItem(item.key, item.value);
    }
}
