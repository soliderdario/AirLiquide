import { Component, OnInit, Injector } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  template: ''
})
export class BaseComponent implements OnInit {

  formulario: FormGroup;
  router: Router;
  route: ActivatedRoute;
  errors: any[] = [];

  nameMask = '';
  maskType = '';
  placeholderMask = '';


  constructor(
    private injector: Injector,
  ) {
    this.router = this.injector.get<Router>(Router);
    this.route = this.injector.get<ActivatedRoute>(ActivatedRoute);

   }

  ngOnInit(): void {
  }

  newGuid(): string {
    let d = new Date().getTime();
    const uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
      const r = (d + Math.random() * 16) % 16 | 0; // tslint:disable-line
      d = Math.floor(d / 16);
      return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16); // tslint:disable-line
    });
    return uuid;
  }

  null(): string {
    return '00000000-0000-0000-0000-000000000000';
  }

  verificaValidTouched(campo: string) {
    return (
      !this.formulario.get(campo).valid &&
      (this.formulario.get(campo).touched || this.formulario.get(campo).dirty)
    );
  }

  verificaRequired(campo: string) {
    return (
      this.formulario.get(campo).hasError('required') &&
      (this.formulario.get(campo).touched || this.formulario.get(campo).dirty)
    );
  }

  aplicaCssErro(campo: string) {
    return {
      'has-error': this.verificaValidTouched(campo),
      'has-feedback': this.verificaValidTouched(campo)
    };
  }


}
