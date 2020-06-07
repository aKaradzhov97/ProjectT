import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { tap, filter, take, switchMap, catchError } from 'rxjs/operators';

import * as fromStore from '../store';

@Injectable()
export class NavigationGuard implements CanActivate {
  constructor(private store: Store<fromStore.NavigationState>) {}

  canActivate(): Observable<boolean> {
    return this.checkStore().pipe(
      switchMap(() => of(true)),
      catchError(() => of(false))
    );
  }

  checkStore(): Observable<boolean> {
    return this.store.select(fromStore.getNavigationLoaded).pipe(
      tap((loaded: boolean) => {
        if (!loaded) {
          this.store.dispatch(new fromStore.LoadNavigation());
        }
      }),
      filter((loaded: boolean) => loaded),
      take(1)
    );
    // Take will automatically unsubscribe here from the observable.
  }
}
