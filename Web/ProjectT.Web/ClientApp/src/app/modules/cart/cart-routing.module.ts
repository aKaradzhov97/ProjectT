// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { CartComponent } from './containers/cart/cart.component';

const ROUTES: Routes = [
  {
    path: '',
    component: CartComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class CartRoutingModule {}
