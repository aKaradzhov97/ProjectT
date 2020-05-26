// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { VouchersComponent } from "./containers/vouchers/vouchers.component";

const ROUTES: Routes = [
  {
    path: '',
    component: VouchersComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class VouchersRoutingModule {}
