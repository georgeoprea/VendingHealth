import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {User} from "../user.model";
import {LoginService} from "../login.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private user : User;

  constructor(private loginService: LoginService,
              private cdRef: ChangeDetectorRef,
              private router: Router) {

    this.user =
      {
        username: '',
        password: ''
      };
  }

  ngOnInit() {
  }

  onSubmit(){
    this.loginService.getAdmin().subscribe(
      userResponse => {
        if(userResponse['username'] == this.user.username && userResponse['password'] == this.user.password) {
          console.log("OK");
          this.router.navigate(['products']);
          this.cdRef.detectChanges();
        }
      }
    );
  }
}
