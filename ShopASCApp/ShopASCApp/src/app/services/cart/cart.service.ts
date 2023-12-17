import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/Product';

@Injectable({
 providedIn: 'root',
})

export class CartService {

 public cartItems: Product[]=[];

 addToCart(product: Product) {
  this.cartItems.push(product);
  // localStorage.setItem('pedidos', JSON.stringify(this.cartItems));
  localStorage.setItem('pedidos', JSON.stringify(this.cartItems));
 }

 getCartItems(): Product[] {
  const list = localStorage.getItem('pedidos');
  return this.cartItems = JSON.parse(list || '[]')
  // return this.cartItems = JSON.parse(list || '[]');
 }

 clearCart(){
  localStorage.clear();
 }
}