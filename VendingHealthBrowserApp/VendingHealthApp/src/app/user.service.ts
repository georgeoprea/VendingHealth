import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import {User} from "./sign-up/user.model";
import {forEach} from "@angular/router/src/utils/collection";
import "rxjs/add/operator/map";
import {UserCard} from "./login/analytics/user-card.model";

@Injectable()
export class UserService {

  private firebase = 'https://vendinghealth-alpha.firebaseio.com/Users';

  constructor(private http : HttpClient) { }

  getCards() : Observable<Response>{
    return this.http.get<Response>(this.firebase + '.json');
  }

  registerUser(user : User, cardKey : string) : Observable<Response>{
    return this.http.patch<Response>(this.firebase + "/" + cardKey + '.json', user);
  }

  getUserCards() : Observable<UserCard[]>{
    return this.http.get(this.firebase + '.json')
      .map((response) => {
        let userCards: UserCard[] = [];
        let keys = Object.keys(response);
        for(let key of keys)
          if( response[key]['username'] != 'admin')
            userCards.push({
              username: response[key]['username'],
              cardNumber: key
            });
        return userCards;
      });
  }
}
