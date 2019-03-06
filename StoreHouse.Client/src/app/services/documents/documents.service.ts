import { Injectable } from '@angular/core';
import 'rxjs';
import { BaseService } from '../baseService';
import { DocumentAddModel } from '../../models/documents/documentAddModel';

@Injectable()
export class DocumentsService extends BaseService {

  getItems() {
    let uri = this.baseUri + 'api/Documents/GetItems';
    console.log(uri);

    return this.http.get(uri)
      .map(respond => respond.json());
  }

  getItemById(id: string) {
    let uri = this.baseUri + 'api/Documents/GetItemById?id=' + id;
    console.log(uri);

    return this.http.get(uri)
      .map(respond => respond.json());
  }

  getItemAddModel() {
    let uri = this.baseUri + 'api/Documents/AddItem';
    console.log(uri);

    return this.http.get(uri)
      .map(respond => respond.json());
  }

  addItem(model: DocumentAddModel) {
    let uri = this.baseUri + 'api/Documents/AddNewItem';
    console.log(uri);

    return this.http.post(uri, model)
      .map(respond => respond.json());
  }
}
