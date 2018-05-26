import { Component, OnInit } from '@angular/core';
import {Product} from "../../home/product.model";
import {ProductRegisterService} from "../../product-register.service";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  private product : Product;
  private position : string;

  constructor(private productsService : ProductRegisterService) {
    this.position = "";
    this.product={
      name:'',
      image:''
    }
  }

  ngOnInit() {
  }

  onSubmit(){
    console.log(this.product);
    console.log(this.position);
    this.productsService.save(this.product, this.position).subscribe(response => console.log(response));
  }

}
