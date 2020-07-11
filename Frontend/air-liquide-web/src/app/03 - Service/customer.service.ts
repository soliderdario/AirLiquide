import { Injectable, Injector } from '@angular/core';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { CustomerModel } from '../02 - Domain/model';
import { OperationType } from '../02 - Domain/types';

import { BaseService } from './base-service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends BaseService {

  constructor(
    injector: Injector
  ) {

    super(injector);
  }

  get(): Observable<CustomerModel[]> {
    return this
      .httpClient
      .get<CustomerModel[]>(this.getApiUrl() + 'customer/query', this.getHeaderJson());
  }

  save(customer: CustomerModel): Observable<CustomerModel> {

    if (customer.Operation === OperationType.Insert) {
      return this.httpClient.post(this.getApiUrl() + 'customer/insert', JSON.stringify(customer), this.getHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));
    }
    else {
      return this.httpClient.put(this.getApiUrl() + 'customer/update', JSON.stringify(customer), this.getHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));
    }
  }

  delete(id: string): Observable<any> {
    return this.httpClient.delete(this.getApiUrl() + `customer/delete/${id}`, this.getHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));
  }
}
