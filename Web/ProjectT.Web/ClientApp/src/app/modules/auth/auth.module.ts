// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers, effects } from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth-routing.module';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../../shared/shared.module';

// Guards

// Services
import { UserService } from '../../core/services/user.service';

// Components
import { AuthContainerComponent } from './containers/auth/auth-container.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    AuthContainerComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AuthRoutingModule,
    MaterialModule,
    StoreModule.forFeature('auth', reducers),
    EffectsModule.forFeature(effects),
    SharedModule,
  ],
  providers: [
    UserService,
    // fromGuards.guards,
  ],
})
export class AuthModule {}
