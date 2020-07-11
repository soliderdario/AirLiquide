import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { NgxPaginationModule } from 'ngx-pagination';

import { MsModalModule } from './../../04 - Infrastrucuture/modal/ms-modal.module';

import { CustomerComponent } from './customer.component';
import { CustomerRoutes } from './customer.routing';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

@NgModule({
  imports: [
    CommonModule,
    CustomerRoutes,
    ReactiveFormsModule,
    FormsModule,
    NgxMaskModule.forRoot(options),
    NgxPaginationModule,
    MsModalModule
  ],
  declarations: [
    CustomerComponent,
    CreateComponent
  ],
  exports: [
    CustomerComponent
  ]
})
export class CustomerModule { }
