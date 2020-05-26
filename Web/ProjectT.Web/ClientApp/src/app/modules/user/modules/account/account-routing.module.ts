// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { AccountComponent } from './containers/account/account.component';

const ROUTES: Routes = [
  {
    path: '',
    component: AccountComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
