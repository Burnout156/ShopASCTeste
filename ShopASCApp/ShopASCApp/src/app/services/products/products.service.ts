import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { Product } from 'src/app/models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private products = [
    { id: 1, name: 'Product 1', price: 10.99 },
    { id: 2, name: 'Product 2', price: 19.99 },
  ];

  readonly rootURL = 'https://localhost:7171/api';

  private cart: any[] = [];

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<any[]>(this.rootURL + '/Product');
  }

  addToCart(product: Product){
    this.cart.push(product);
  }

  getCart() {
    return of(this.cart);
  }

  createProduct(product: Product) {
    debugger
    return this.http.post(this.rootURL + '/Product', product);  
  }
  
}
