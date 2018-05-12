import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Product} from "./home/product.model";
import {Observable} from "rxjs/Observable";

@Injectable()
export class ProductRegisterService {

  private firebase = 'https://vendinghealth-alpha.firebaseio.com/Products';

  constructor(private http : HttpClient) { }

  save(product : Product, position : string) : Observable<Response>{
    return this.http.patch<Response>(this.firebase + "/" + position + " .json", product);
  }
}
