// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { OrdersComponent } from './containers/orders/orders.component';

const ROUTES: Routes = [
  {
    path: '',
    component: OrdersComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class OrdersRoutingModule {}
