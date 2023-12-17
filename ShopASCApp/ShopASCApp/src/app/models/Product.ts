import { Category } from "./Category";

export interface Product {
    name: string;
    price: number;
    categoryId: number;
    category: Category;
  }
  