// Decorators & Lifehooks
import {
  ChangeDetectionStrategy,
  Component,
  ViewEncapsulation,
} from '@angular/core';

// NGRX
import { Store } from '@ngrx/store';
import * as fromStore from '../../store';

@Component({
  selector: 'app-auth-container',
  templateUrl: './auth-container.component.html',
  styleUrls: ['./auth-container.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None,
})
export class AuthContainerComponent {
  step = 0;

  constructor(private store: Store<fromStore.UserState>) {}

  setStep(index: number) {
    this.step = index;
  }

  onLoginSubmit(value): void {
    this.store.dispatch(new fromStore.LoginUser(value));
  }

  onRegisterSubmit(value): void {
    this.store.dispatch(new fromStore.RegisterUser(value));
  }
}
