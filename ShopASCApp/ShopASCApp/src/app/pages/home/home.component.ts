import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/Category';
import { ItemList } from 'src/app/shared/Data/products/product-list';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  productsList = ItemList;
  productsMoreSale: any[] = [];
  productsMoreSaleFiltered: any[] = [];
  searchMoreSale: string = '';
  
  productsInPromotion: any[] = [];
  productsInPromotionFiltered: any[] = [];
  searchProductsPromotion: string = '';

  constructor() { }

  ngOnInit(): void {
    this.getProductsMoreSale(this.productsList);
    this.getProductsInPromotion(this.productsList);
  }

  onSearch() {
    if (this.searchMoreSale.trim() === '') {
      this.productsMoreSaleFiltered = [...this.productsMoreSale];
    } else {
      this.productsMoreSaleFiltered = this.productsMoreSale.filter(product => {
        return product.name.toLowerCase().includes(this.searchMoreSale.toLowerCase());
      });
    }
  }

  onSearchProductsPromotion() {
    if (this.searchProductsPromotion.trim() === '') {
      this.productsInPromotionFiltered = [...this.productsInPromotion];
    } else {
      this.productsInPromotionFiltered = this.productsInPromotion.filter(product => {
        return product.name.toLowerCase().includes(this.searchProductsPromotion.toLowerCase());
      });
    }
  }

  getProductsMoreSale(products: any) {
    this.productsMoreSale = products.filter((item: { bestSeller: boolean; }) => item.bestSeller === true);
    this.productsMoreSaleFiltered = this.productsMoreSale;
    console.log("Produtos mais vendidos:", this.productsMoreSaleFiltered)
  }

  getProductsInPromotion(products: any) {
    this.productsInPromotion = products.filter((item: { promotion: boolean; }) => item.promotion === true);
    this.productsInPromotionFiltered = this.productsInPromotion;
    console.log("Produtos mais vendidos:", this.productsInPromotionFiltered)
  }

  getCategoryProduct(category: Category): string {
    switch (category.id) {
      case 1:
        return 'Computador';
  
      case 2:
        return 'Telefone';
  
      case 3:
        return 'Eletronico';
  
      default:
        return '';
    }
  }
}
