import { Injectable } from '@angular/core';

import { Effect, Actions, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { map, switchMap, catchError } from 'rxjs/operators';

import * as navigationActions from '../actions/navigation.action';
import * as fromServices from '../../core/services/navigation.service';

@Injectable()
export class NavigationEffect {
  constructor(
    private actions$: Actions,
    private navigationService: fromServices.NavigationService
  ) {}

  @Effect()
  loadNavigation$ = this.actions$.pipe(
    ofType(navigationActions.LOAD_NAVIGATION),
    switchMap(() => {
      return this.navigationService.getNavigation().pipe(
        map(
          (navigation) =>
            new navigationActions.LoadNavigationSuccess(navigation)
        ),
        catchError((error) =>
          of(new navigationActions.LoadNavigationFail(error))
        )
      );
    })
  );
}
