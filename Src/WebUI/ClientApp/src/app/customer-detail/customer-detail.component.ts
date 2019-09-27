import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { CustomerDetailVm } from '../northwind-traders-api';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CustomerDetailComponent implements OnInit {
  public customer: CustomerDetailVm;
  public detailKeys: string[] = [];

  constructor(private bsModalRef: BsModalRef) {}

  ngOnInit() {
    this.detailKeys = Object
      .keys(this.customer)
      .filter(keys => keys !== 'id');
  }

  public closeModal() {
    this.bsModalRef.hide();
  }

}
