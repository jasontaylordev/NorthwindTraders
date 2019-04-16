import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { CustomerDetailModel } from '../northwind-traders-api';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomerDetailComponent implements OnInit {
  public customer: CustomerDetailModel;
  public detailKeys: string[] = [];

  constructor(private bsModalRef: BsModalRef) {}

  ngOnInit() {
    this.detailKeys = Object
      .keys(this.customer)
      .filter(keys => keys !== 'id');
  }

  closeModal() {
    this.bsModalRef.hide();
  }

}
