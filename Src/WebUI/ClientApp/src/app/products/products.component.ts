import { Component } from '@angular/core';
import { ProductsClient, ProductsListViewModel } from '../northwind-traders-api';

@Component({
  templateUrl: './products.component.html'
})
export class ProductsComponent {

  productsListVm: ProductsListViewModel = new ProductsListViewModel();

  constructor(client: ProductsClient) {
    client.getAll().subscribe(result => {
      this.productsListVm = result;
    }, error => console.error(error));
  }
}
