import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products/products.service';
import { CategoryService } from 'src/app/services/category/category.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {

  productForm: FormGroup | any;
  name: string = '';
  price: number = 0;
  categories: any[] = []; // Lista de categorias

  constructor(
    private formBuilder: FormBuilder,
    private productService: ProductsService,
    private categoryService: CategoryService, // Injete o serviço de categoria
    private router: Router
  ) { }

  ngOnInit(): void {
    debugger
    this.productForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      price: [0, [Validators.required, Validators.min(0)]],
      categoryId: [0, [Validators.required]]
    });

    this.categoryService.getCategories().subscribe((data) => {
      this.categories = data;
    });
  }

  onSubmit(): void {
    debugger
    if (this.productForm.valid) {
      this.productService.createProduct(this.productForm.value)
        .subscribe({
          next: () => {
            this.router.navigate(['/products']);
          },
          error: error => {
            console.error('Erro ao criar o produto:', error);
          }
        });
    } 
  }
}
