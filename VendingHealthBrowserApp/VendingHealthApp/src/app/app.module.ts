import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {ButtonModule} from 'primeng/button';
import {FormsModule} from "@angular/forms";
import {LoginService} from "./login.service";
import { SignUpComponent } from './sign-up/sign-up.component';
import { ProductsComponent } from './login/products/products.component';
import {UserService} from "./user.service";
import {RouterModule, Routes} from "@angular/router";
import {HttpClientModule} from "@angular/common/http";
import { HomeComponent } from './home/home.component';
import {ProductRegisterService} from "./product-register.service";
import { AnalyticsComponent } from './login/analytics/analytics.component';
import {ChartService} from "./login/analytics/chart.service";
import { ChartDisplayComponent } from './login/analytics/chart-display/chart-display.component';

const ROUTES: Routes = [
  {path: '', component: HomeComponent},
  {path: 'signup', component: SignUpComponent},
  {path: 'products', component: ProductsComponent},
  {path: 'analytics', component: AnalyticsComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    ProductsComponent,
    HomeComponent,
    AnalyticsComponent,
    ChartDisplayComponent
  ],
  imports: [
    RouterModule.forRoot(ROUTES),
    BrowserModule,
    HttpClientModule,
    ButtonModule,
    FormsModule
  ],
  providers: [
    LoginService,
    UserService,
    ProductRegisterService,
    ChartService,
    HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
