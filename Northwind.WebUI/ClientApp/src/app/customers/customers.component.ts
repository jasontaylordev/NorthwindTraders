import { Component } from '@angular/core';
import { CustomersClient, CustomerListModel } from '../northwind-traders-api';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent {

  customers: CustomerListModel[];

  constructor(client: CustomersClient) {
    client.getAll().subscribe(result => {
      this.customers = result;
    }, error => console.error(error));
  }
}
