import { Injectable } from '@angular/core';
import 'rxjs';
import { BaseService } from '../baseService';

@Injectable()
export class WarehousesService extends BaseService {

  getItems() {
    var uri = this.baseUri + "api/Warehouses/GetItems";     
    console.log(uri);

    return this.http.get(uri)
      .map(respond => respond.json());
  }

  getItemById(id: string) {
    var uri = this.baseUri + "api/Warehouses/GetItemById?id=" + id;     
    console.log(uri);

    return this.http.get(uri)
      .map(respond => respond.json());
  }
}
