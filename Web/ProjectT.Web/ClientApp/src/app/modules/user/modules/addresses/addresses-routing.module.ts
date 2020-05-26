// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { AddressesComponent } from "./containers/addresses/addresses.component";

const ROUTES: Routes = [
  {
    path: '',
    component: AddressesComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class AddressesRoutingModule {}
