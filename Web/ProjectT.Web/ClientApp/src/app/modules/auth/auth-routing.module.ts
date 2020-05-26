// Decorators
import { NgModule } from '@angular/core';

// Modules
import { RouterModule, Routes } from '@angular/router';

// Guards

// Components
import { AuthContainerComponent } from './containers/auth/auth-container.component';

const ROUTES: Routes = [
  {
    path: '',
    component: AuthContainerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(ROUTES)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
