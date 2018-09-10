import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class BaseService {

  protected baseUri: string = "http://localhost:4201/" 

  protected http: Http;

  constructor(http: Http) {
    this.http = http;
  }
}