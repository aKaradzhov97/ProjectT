// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { WishListComponent } from './containers/wish-list/wish-list.component';

const ROUTES: Routes = [
  {
    path: '',
    component: WishListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class WishRoutingModule {}
