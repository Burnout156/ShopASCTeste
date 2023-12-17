// Order.ts

import { Product } from "./Product";

export interface Order {
  id: number;
  orderDate: Date;
  customerName: string;
  shippingAddress: string;
  orderProducts: Product[];
}
