// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { UserAccountComponent } from './containers/user-account/user-account.component';

const ROUTES: Routes = [
  {
    path: '',
    component: UserAccountComponent,
    children: [
      {
        path: 'account',
        loadChildren: () =>
          import('./modules/account/account.module').then(
            (m) => m.AccountModule
          ),
      },
      {
        path: 'addresses',
        loadChildren: () =>
          import('./modules/addresses/addresses.module').then(
            (m) => m.AddressesModule
          ),
      },
      {
        path: 'details',
        loadChildren: () =>
          import('./modules/details/details.module').then(
            (m) => m.DetailsModule
          ),
      },
      {
        path: 'newsletters',
        loadChildren: () =>
          import('./modules/newsletters/newsletters.module').then(
            (m) => m.NewslettersModule
          ),
      },
      {
        path: 'orders',
        loadChildren: () =>
          import('./modules/orders/orders.module').then((m) => m.OrdersModule),
      },
      {
        path: 'vouchers',
        loadChildren: () =>
          import('./modules/vouchers/vouchers.module').then(
            (m) => m.VouchersModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
