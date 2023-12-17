import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { Product } from 'src/app/models/Product';
import { Order } from 'src/app/models/Order';
import { OrderService } from 'src/app/services/order/order.service';
import { CartService } from 'src/app/services/cart/cart.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  orders: Order[] = [];
  form: FormGroup | undefined;

  constructor(
    private orderService: OrderService,
    private cartService: CartService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.loadOrders();
    // this.initForm();
  }

  loadOrders(): void {
    this.orderService.getOrders().subscribe({
      next: (data: Order[]) => {
        this.orders = data;
      },
      error: (error: any) => {
        console.error('Erro ao carregar pedidos', error);
      }
    });
  }

  // finishOrder(): void {
  //   if (!this.form) {
  //       console.error('Formulário não inicializado.');
  //       return;
  //   }

  //   const customerName = this.form.get('customerName')?.value;
  //   const shippingAddress = this.form.get('shippingAddress')?.value;

  //   // Converta os produtos no carrinho para OrderProducts antes de criar o pedido
  //   const orderProducts: OrderProduct[] = this.cartService.cartItems.map(convertToOrderProduct);

  //   // Crie um objeto Order com base nos dados do formulário e nos OrderProducts
  //   const order: Order = {
  //       id: 0, // Ajuste conforme necessário
  //       orderDate: new Date(),
  //       customerName,
  //       shippingAddress,
  //       orderProducts,
  //   };

  //   this.cartService.clearCart();
  //   this.orderService.createOrder(order);
  // }

}
