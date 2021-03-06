// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
// import {reducers, effects} from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DetailsRoutingModule } from './details-routing.module';
import { MaterialModule } from '../../../material/material.module';
import { UserSharedModule } from "../../shared/user-shared.module";

// Guards

// Services
import { UserService } from '../../../../core/services/user.service';

// Components
import { DetailsComponent } from './containers/details/details.component';

@NgModule({
  declarations: [DetailsComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    DetailsRoutingModule,
    MaterialModule,
    UserSharedModule,
    // StoreModule.forFeature('auth', reducers),
    // EffectsModule.forFeature(effects),
  ],
  providers: [
    UserService,
    // fromGuards.guards,
  ],
})
export class DetailsModule {}
