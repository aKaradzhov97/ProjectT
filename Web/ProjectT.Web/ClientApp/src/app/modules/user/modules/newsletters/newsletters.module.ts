// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
// import {reducers, effects} from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NewslettersRoutingModule } from "./newsletters-routing.module";
import { MaterialModule } from '../../../material/material.module';
import { UserSharedModule } from '../../shared/user-shared.module';

// Guards

// Services
import { UserService } from '../../../../core/services/user.service';

// Components
import { NewslettersComponent } from './containers/newsletters/newsletters.component';

@NgModule({
  declarations: [NewslettersComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NewslettersRoutingModule,
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
export class NewslettersModule {}
