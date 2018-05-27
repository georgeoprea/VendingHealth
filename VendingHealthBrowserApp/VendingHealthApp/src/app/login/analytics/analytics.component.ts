import {Component, OnInit} from '@angular/core';
import {UserService} from "../../user.service";
import {UserCard} from "./user-card.model";

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.css']
})

export class AnalyticsComponent implements OnInit {

  private usernamesAndCards : UserCard[];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getUserCards();
  }

  getUserCards() : void{
    this.userService.getUserCards().subscribe(
      (usernamesAndCards) => {
        this.usernamesAndCards = usernamesAndCards;
      }
    );
  }
}
