import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer.component';
const routes: Routes = [
  {
    path: '',
    redirectTo: 'list'
    },
    {
      path: 'list',
      component: CustomerComponent
    },
  ];

export const CustomerRoutes = RouterModule.forChild(routes);
