// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
// import {reducers, effects} from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { CartRoutingModule } from './cart-routing.module';

// Guards

// Services

// Components
import { CartComponent } from './containers/cart/cart.component';

@NgModule({
  declarations: [CartComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
    CartRoutingModule,
    // StoreModule.forFeature('auth', reducers),
    // EffectsModule.forFeature(effects),
  ],
  providers: [
    // fromGuards.guards,
  ],
})
export class CartModule {}
