import { Component } from '@angular/core';
import { CustomersClient, CustomersListViewModel } from '../northwind-traders-api';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { BsModalService } from 'ngx-bootstrap/modal/bs-modal.service';
import { CustomerDetailComponent } from '../customer-detail/customer-detail.component';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html'
})
export class CustomersComponent {

  public vm: CustomersListViewModel = new CustomersListViewModel();
  private bsModalRef: BsModalRef;

  constructor(private client: CustomersClient, private modalService: BsModalService) {
    client.getAll().subscribe(result => {
      this.vm = result;
    }, error => console.error(error));
  }

  customerDetail(id: string) {
    this.client.get(id).subscribe(result => {
      const initialState = {
        customer: result
      };
      this.bsModalRef = this.modalService.show(CustomerDetailComponent, {initialState});
    }, error => console.error(error));
  }
}
