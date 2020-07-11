import { environment } from './../../environments/environment.prod';
import { Injector } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';


export abstract class BaseService {

  protected httpClient: HttpClient;

  constructor(
    private injector: Injector,
  ) {
    this.httpClient = this.injector.get<HttpClient>(HttpClient);
  }

  protected getApiUrl() {
    return environment.ApiUrl;
  }


  protected getHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8'
      })
    };
  }

  protected getHeaderFormData(name: string) {
    return {
      headers: new HttpHeaders({
        'Content-Disposition': `form-data; name= "${name}"`, // form-data; name="produto"',
        Authorization: `Bearer ${this.getUserToken()}`
      })
    };
  }

  protected getAuthHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: `Bearer ${this.getUserToken()}`
      })
    };
  }

  protected getUserToken(): string {
    return localStorage.getItem('app.token');
  }

  protected extractData(response: any) {
    return response.data || {};
  }

  protected serviceError(error: Response | any) {
    let errMsg = '';

    if (error instanceof Response) {

      errMsg = `${error.status} - ${error.statusText || ''}`;
    } else {
      if (error.error === null) {
        if (error.status === 401) {
          errMsg = 'Você não está autorizado para acessar esse módulo!';
        }

      } else {
        error.error.errors.forEach(er => {
          errMsg = errMsg + '<p>' + er + '</p>';

        });
      }
    }
    return throwError(errMsg);
  }
}
