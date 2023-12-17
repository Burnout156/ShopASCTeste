import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './shared/components/header/header.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { ProductsComponent } from './pages/products/products.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderComponent } from './pages/order/order.component';
import { CreateProductComponent } from './pages/products/create-product/create-product.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CreateOrderComponent } from './pages/order/create-order/create-order.component';
import { CartComponent } from './pages/cart/cart.component';
import { CartService } from './services/cart/cart.service';
import { DetailProductComponent } from './pages/products/detail-product/detail-product.component';
import { DetailOrderComponent } from './pages/order/detail-order/detail-order.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    ProductsComponent,
    OrderComponent,
    CreateProductComponent,
    CreateOrderComponent,
    CartComponent,
    DetailProductComponent,
    DetailOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule
  ],
  providers: [CartService],
  bootstrap: [AppComponent]
})

export class AppModule  { 
}


