import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import {UserCard} from "./user-card.model";
import {PlotData} from "./chart-display/plot-data.model";
import {forEach} from "@angular/router/src/utils/collection";

@Injectable()
export class ChartService {

  private firebase = 'https://vendinghealth-alpha.firebaseio.com/Transactions.json';

  constructor(private http : HttpClient) { }

  getHourlyTransactionNumber(userCard: UserCard) : Observable<PlotData[]>{
    return this.http.get(this.firebase)
      .map(
        (response) => {
          let keys = Object.keys(response);
          let plotData = [];
          for(let key of keys) {
            if (userCard.cardNumber == key) {
              let hours = Object.keys(response[key]);
              for (let hour of hours)
                plotData.push({
                  hour: hour,
                  vendedItems: response[key][hour]
                });
            }
          }
          return plotData;
        }
      );
  }
}
