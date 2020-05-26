// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
// import {reducers, effects} from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AddressesRoutingModule } from './addresses-routing.module';
import { MaterialModule } from '../../../material/material.module';

// Guards

// Services
import { UserService } from '../../../../core/services/user.service';

// Components
import { AddressesComponent } from './containers/addresses/addresses.component';

@NgModule({
  declarations: [AddressesComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AddressesRoutingModule,
    MaterialModule,
    // StoreModule.forFeature('auth', reducers),
    // EffectsModule.forFeature(effects),
  ],
  providers: [
    UserService,
    // fromGuards.guards,
  ],
})
export class AddressesModule {}
