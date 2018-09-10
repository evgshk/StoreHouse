import { Injectable } from '@angular/core';
import 'rxjs';
import { BaseService } from '../baseService';

@Injectable()
export class ProductsService extends BaseService{

  getItems() {
    var uri = this.baseUri + "api/Products/GetItems";     
    console.log(uri);

    return this.http.get(uri)
      .map(respond => respond.json());
  }
}
