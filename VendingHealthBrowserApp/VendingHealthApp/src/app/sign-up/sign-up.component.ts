import { Component, OnInit } from '@angular/core';
import {SignUpService} from "../sign-up.service";
import {User} from "../user.model";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  private newUser : User;
  private cardNumber : number;

  constructor(private signupService : SignUpService) {
  }

  ngOnInit() {
    this.newUser = {
      email:'',
      password: '',
      username: '',
      balance: 300
    }
  }

  onSubmit() {
    this.signupService.getCards().subscribe(
      response => {
        console.log(response);
        let key = Object.keys(response)[this.cardNumber];
        if(key =='admin')
          console.log("Stop hacking");
        else
          this.signupService.registerUser(this.newUser, key).subscribe(response => console.log(response));
    });
  }
}
