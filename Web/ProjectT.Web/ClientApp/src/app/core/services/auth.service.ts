// Decorators
import { Injectable } from '@angular/core';

// RXJS
import { Subject } from 'rxjs';

// Models
import { User } from '../../shared/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  isUserLogged = new Subject<boolean>();
  private user: User = null;

  saveSession(user): void {
    this.user = user;
  }

  clearSession(): void {
    this.user = null;
  }

  getProfile(): any {
    return this.user;
  }

  isLoggedIn(): boolean {
    return !!this.user;
  }

  isAdmin(): boolean {
    return this.user ? this.user.isAdmin : false;
  }
}
