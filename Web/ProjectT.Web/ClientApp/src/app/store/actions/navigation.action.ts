import { Action } from '@ngrx/store';

// LOAD NAVIGATION
export const LOAD_NAVIGATION = '[Navigation] Load Navigation';
export const LOAD_NAVIGATION_FAIL = '[Navigation] Load Navigation Fail';
export const LOAD_NAVIGATION_SUCCESS = '[Navigation] Load Navigation Success';

export class LoadNavigation implements Action {
  readonly type = LOAD_NAVIGATION;
}

export class LoadNavigationFail implements Action {
  readonly type = LOAD_NAVIGATION_FAIL;

  constructor(public payload: any) {}
}

export class LoadNavigationSuccess implements Action {
  readonly type = LOAD_NAVIGATION_SUCCESS;

  constructor(public payload: any) {}
}

// Action types
export type NavigationAction =
  | LoadNavigation
  | LoadNavigationFail
  | LoadNavigationSuccess;
