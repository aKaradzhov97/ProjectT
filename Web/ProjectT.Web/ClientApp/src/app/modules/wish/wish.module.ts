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
import { WishRoutingModule } from './wish-routing.module';

// Guards

// Services

// Components
import { WishListComponent } from './containers/wish-list/wish-list.component';

@NgModule({
  declarations: [WishListComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
    WishRoutingModule,
    // StoreModule.forFeature('auth', reducers),
    // EffectsModule.forFeature(effects),
  ],
  providers: [
    // fromGuards.guards,
  ],
})
export class WishModule {}
