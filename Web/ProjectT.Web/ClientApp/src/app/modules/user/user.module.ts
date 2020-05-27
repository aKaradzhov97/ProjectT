// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
// import {reducers, effects} from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { UserRoutingModule } from './user-routing.module';
import { MaterialModule } from '../material/material.module';

// Guards

// Services
import { UserService } from '../../core/services/user.service';

// Components
import { UserAccountComponent } from './containers/user-account/user-account.component';
import { UserSidenavComponent } from './components/user-sidenav/user-sidenav.component';

@NgModule({
  declarations: [UserAccountComponent, UserSidenavComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    UserRoutingModule,
    MaterialModule,
    // StoreModule.forFeature('auth', reducers),
    // EffectsModule.forFeature(effects),
  ],
  providers: [
    UserService,
    // fromGuards.guards,
  ],
})
export class UserModule {}
