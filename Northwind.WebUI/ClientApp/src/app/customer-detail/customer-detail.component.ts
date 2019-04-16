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
  public detailLabelKeys: string[] = [];
  constructor(public bsModalRef: BsModalRef) {

   }

  ngOnInit() {
    this.detailKeys = Object
      .keys(this.customer)
      .filter(keys => keys !== 'id');
    this.detailLabelKeys = this.detailKeys.map(key => key.match(/[A-Z][a-z]+|[a-z]+/g).join(' '));
  }

}
