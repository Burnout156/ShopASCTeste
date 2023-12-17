import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProductsComponent } from './pages/products/products.component';
import { OrderComponent } from './pages/order/order.component';
import { CreateProductComponent } from './pages/products/create-product/create-product.component';
import { CreateOrderComponent } from './pages/order/create-order/create-order.component';
import { CartComponent } from './pages/cart/cart.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'products', component: ProductsComponent},
  { path: 'create-product', component: CreateProductComponent },
  { path: 'orders', component: OrderComponent },
  { path: 'create-orders', component: CreateOrderComponent },
  { path: 'cart', component: CartComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
