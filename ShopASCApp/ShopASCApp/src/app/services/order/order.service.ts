import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from 'src/app/models/Order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly rootURL = 'https://localhost:7171/api';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.rootURL}/Order`);
  }

  createOrder(order: Order): Observable<any> {
    return this.http.post(`${this.rootURL}/Order`, order);
  }
  

}
