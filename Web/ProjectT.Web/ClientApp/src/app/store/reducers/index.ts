import {
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Params,
} from '@angular/router';
import { createFeatureSelector } from '@ngrx/store';

import * as fromNavigation from './navigation.reducer';
import * as fromRouter from '@ngrx/router-store';

// NAVIGATION

export interface NavigationState {
  navigation: fromNavigation.NavigationState;
}

export const getNavigationState = createFeatureSelector<NavigationState>(
  'navigation'
);

// ROUTER

export interface RouterStateUrl {
  url: string;
  queryParams: Params;
  params: Params;
}

export interface State {
  routerReducer: fromRouter.RouterReducerState<RouterStateUrl>;
}

export const getRouterState = createFeatureSelector<
  fromRouter.RouterReducerState<RouterStateUrl>
>('routerReducer');

export class CustomSerializer
  implements fromRouter.RouterStateSerializer<RouterStateUrl> {
  serialize(routerState: RouterStateSnapshot): RouterStateUrl {
    const { url } = routerState;
    const { queryParams } = routerState.root;

    let state: ActivatedRouteSnapshot = routerState.root;

    while (state.firstChild) {
      state = state.firstChild;
    }

    const { params } = state;

    return { url, queryParams, params };
  }
}

export const reducers = {
  navigation: fromNavigation.reducer,
  routerReducer: fromRouter.routerReducer,
};
