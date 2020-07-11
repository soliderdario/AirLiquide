import { Component, OnInit, Input, Output, EventEmitter, Injector } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { CustomerModel } from 'src/app/02 - Domain/model';

import { CustomerService } from 'src/app/03 - Service/customer.service';

import { MsModalService } from 'src/app/04 - Infrastrucuture/modal/ms-modal.service';

import { BaseComponent } from '../../base-component';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent extends BaseComponent implements OnInit {

  @Input() id: string;
  @Input() customer: CustomerModel;
  @Output() callbackCustomer: EventEmitter<CustomerModel> = new EventEmitter();

  constructor(
    injector: Injector,
    private fb: FormBuilder,
    private customerService: CustomerService,
    private modalService: MsModalService
  ) {
    super(injector);
  }

  private initialize(customer: CustomerModel): void {
    this.formulario = this.fb.group({
      Id: customer.Id,
      Name: [customer.Name, Validators.required],
      Age: [customer.Age, Validators.required],
      Operation: [customer.Operation]
    });
  }

  ngOnInit(): void {
    super.ngOnInit();
    this.initialize(this.customer);
  }

  onSave(): void {
    this.errors = new Array<any>();
    if (!this.formulario.valid) {
      this.errors.push('Verifique se os campos obrigatórios foram preenchidos!');
      return;
    }

    const customer: CustomerModel = Object.assign({}, new CustomerModel(), this.formulario.value);
    this.customerService.save(customer).subscribe(
      (response) => {

        this.callbackCustomer.emit(response);
        this.modalService.close(this.id);

      },
      (fail) => {
        this.errors = fail.error.errors;
      });
  }
  onClose(): void {
    this.formulario.reset();
    this.callbackCustomer.emit(null);
    this.modalService.close(this.id);
  }

}

