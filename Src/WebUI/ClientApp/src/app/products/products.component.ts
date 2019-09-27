import { Component } from '@angular/core';
import { ProductsClient, ProductsListVm } from '../northwind-traders-api';

@Component({
  templateUrl: './products.component.html'
})
export class ProductsComponent {

  productsListVm: ProductsListVm = new ProductsListVm();

  constructor(client: ProductsClient) {
    client.getAll().subscribe(result => {
      this.productsListVm = result;
    }, error => console.error(error));
  }
}
