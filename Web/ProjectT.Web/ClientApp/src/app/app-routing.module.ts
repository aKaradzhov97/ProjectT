// Decorators
import { NgModule } from '@angular/core';

// Modules
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

// Guards
import { NavigationGuard } from './guards';

const ROUTES: Routes = [
  {
    path: 'cart',
    loadChildren: () =>
      import('./modules/cart/cart.module').then((m) => m.CartModule),
    canActivate: [NavigationGuard],
  },
  {
    path: 'wishlist',
    loadChildren: () =>
      import('./modules/wish/wish.module').then((m) => m.WishModule),
    canActivate: [NavigationGuard],
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'user',
    loadChildren: () =>
      import('./modules/user/user.module').then((m) => m.UserModule),
    canActivate: [NavigationGuard],
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./modules/auth/auth.module').then((m) => m.AuthModule),
    canActivate: [NavigationGuard],
  },
  {
    path: '',
    loadChildren: () =>
      import('./modules/home/home.module').then((m) => m.HomeModule),
    canActivate: [NavigationGuard],
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(ROUTES, {
      initialNavigation: 'enabled',
      preloadingStrategy: PreloadAllModules,
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
