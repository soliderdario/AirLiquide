import { Component, OnInit, Injector } from '@angular/core';

import { CustomerModel } from '../../02 - Domain/model';
import { OperationType } from '../../02 - Domain/types';

import { CustomerService } from './../../03 - Service/customer.service';

import { MsModalService } from './../../04 - Infrastrucuture/modal/ms-modal.service';

import { BaseComponent } from '../base-component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent extends BaseComponent implements OnInit {

  customers = new Array<CustomerModel>();
  customer: CustomerModel = null;
  page = 1;

  constructor(
    injector: Injector,
    private customerService: CustomerService,
    private modalService: MsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.customerService.get().subscribe(resp => {
      this.customers = resp;
    });
  }

  new(id: string): void {
    this.customer = new CustomerModel();
    this.customer.Id = this.newGuid();
    this.customer.Operation = OperationType.Insert;
    this.modalService.open(id);
  }

  edit(customer: CustomerModel, id: string): void {
    this.customer = Object.assign({}, new CustomerModel(), customer);
    this.customer.Operation = OperationType.Update;
    this.modalService.open(id);

  }

  delete(Id: string): void {
    this.customerService.delete(Id).subscribe(() => {
      const index = this.customers.findIndex(src => src.Id === Id);
      this.customers.splice(index, 1);
    });
  }

  onCallbackCustomer(customer: CustomerModel): void {
    this.customer = null;
    if (customer === null) {
      return;
    }
    const index = this.customers.findIndex(src => src.Id === customer.Id);
    if (index === -1) {
      this.customers.push(customer);
    } else {
      this.customers[index] = customer;
    }
  }
}

