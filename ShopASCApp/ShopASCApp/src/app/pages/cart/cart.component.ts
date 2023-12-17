// cart.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Order } from 'src/app/models/Order';
import { Product } from 'src/app/models/Product';
import { CartService } from 'src/app/services/cart/cart.service';
import { OrderService } from 'src/app/services/order/order.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {

  form: FormGroup;
  cartItems: any[]; // Declare cartItems

  constructor(
    private formBuilder: FormBuilder,
    private orderService: OrderService,
    private cartService: CartService
  ) {
    this.form = this.formBuilder.group({
      customerName: '',
      shippingAddress: '',
    });

    const list = localStorage.getItem('pedidos');
    this.cartItems = JSON.parse(list || '[]');
  }

  ngOnInit(): void {
    const list = localStorage.getItem('pedidos');
    this.cartItems = JSON.parse(list || '[]');
  }

  finishOrder(): void {
    if (!this.form) {
      console.error('Formulário não inicializado.');
      return;
    }

    const customerName = this.form.get('customerName')?.value;
    const shippingAddress = this.form.get('shippingAddress')?.value;

    const orderProducts: Product[] = this.cartItems.map((item: any) => {
      return {
        id: item.product.id,
        name: item.product.name,
        price: item.product.price,
        categoryId: item.product.categoryId,
        category: item.product.category,
      } as Product;
    });

    const order: Order = {
      id: 0, // Ajuste conforme necessário
      orderDate: new Date(),
      customerName,
      shippingAddress,
      orderProducts,
    };

    this.cartService.clearCart();
    this.orderService.createOrder(order);
  }
}
