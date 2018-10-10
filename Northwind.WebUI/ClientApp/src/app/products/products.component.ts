import { Component } from '@angular/core';
import { ProductsClient, ProductsListViewModel } from '../northwind-traders-api';

@Component({
  templateUrl: './products.component.html'
})
export class ProductsComponent {

  productsListVm: ProductsListViewModel;

  constructor(client: ProductsClient) {
    client.getProducts().subscribe(result => {
      this.productsListVm = result;
      console.log(result);
    }, error => console.error(error));
  }
}
