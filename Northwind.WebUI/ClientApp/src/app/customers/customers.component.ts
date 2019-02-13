import { Component } from '@angular/core';
import { CustomersClient, CustomersListViewModel } from '../northwind-traders-api';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent {

  vm: CustomersListViewModel = new CustomersListViewModel();

  constructor(client: CustomersClient) {
    client.getAll().subscribe(result => {
      this.vm = result;
    }, error => console.error(error));
  }
}
