import * as fromNavigation from '../actions/navigation.action';

import { Category } from '@shared/models/category.model';

export interface NavigationState {
  entities: { [id: string]: Category };
  loaded: boolean;
  loading: boolean;
}

export const initialState: NavigationState = {
  entities: {},
  loaded: false,
  loading: false,
};

export function reducer(
  state = initialState,
  action: fromNavigation.NavigationAction
): NavigationState {
  switch (action.type) {
    case fromNavigation.LOAD_NAVIGATION: {
      return {
        ...state,
        loading: true,
      };
    }

    case fromNavigation.LOAD_NAVIGATION_SUCCESS: {
      const categories: Category[] = action.payload.data;
      const entities = categories.reduce(
        (entities: { [id: string]: Category }, category: Category) => {
          return {
            ...entities,
            [category.id]: category,
          };
        },
        {
          ...state.entities,
        }
      );

      return {
        ...state,
        loading: false,
        loaded: true,
        entities,
      };
    }

    case fromNavigation.LOAD_NAVIGATION_FAIL: {
      return {
        ...state,
        loading: false,
        loaded: false,
      };
    }
  }

  return state;
}

export const getNavigationEntities = (state: NavigationState) => state.entities;
export const getNavigationLoading = (state: NavigationState) => state.loading;
export const getNavigationLoaded = (state: NavigationState) => state.loaded;
