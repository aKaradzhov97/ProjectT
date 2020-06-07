// NGRX
import { createSelector } from '@ngrx/store';

import * as fromFeature from '../reducers';
import * as fromNavigation from '../reducers/navigation.reducer';

// Selectors
export const getNavigationStateSelector = createSelector(
  fromFeature.getNavigationState,
  (state: fromFeature.NavigationState) => state.navigation
);

export const getNavigationEntities = createSelector(
  getNavigationStateSelector,
  fromNavigation.getNavigationEntities
);

export const getNavigation = createSelector(
  getNavigationEntities,
  (entities) => {
    return Object.keys(entities).map((id) => entities[id]);
  }
);

export const getNavigationLoaded = createSelector(
  getNavigationStateSelector,
  fromNavigation.getNavigationLoaded
);
export const getNavigationLoading = createSelector(
  getNavigationStateSelector,
  fromNavigation.getNavigationLoading
);
