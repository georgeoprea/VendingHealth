import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import {User} from "./user.model";

@Injectable()
export class SignUpService {

  private firebase = 'https://vendinghealth-alpha.firebaseio.com/Users';

  constructor(private http : HttpClient) { }

  getCards() : Observable<Response>{
    return this.http.get<Response>(this.firebase + '.json');
  }

  registerUser(user : User, cardKey : string) : Observable<Response>{
    return this.http.patch<Response>(this.firebase + "/" + cardKey + '.json', user);
  }

}
