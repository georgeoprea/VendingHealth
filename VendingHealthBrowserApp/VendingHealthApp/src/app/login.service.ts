import { Injectable } from '@angular/core';
import {User} from "./user.model";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";

@Injectable()
export class LoginService {

  private firebase = 'https://vendinghealth-alpha.firebaseio.com/Users/admin.json';
  private credentialsOK : boolean;

  constructor(private http : HttpClient) { }

  getAdmin() : Observable<User>{
    return this.http.get<User>(this.firebase);
  }

}
