import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router : Router,
              private http : HttpClient){

  }

  ngOnInit() {
  }

  goToSignup() : void{
    this.router.navigate(['signup']);
  }

}
