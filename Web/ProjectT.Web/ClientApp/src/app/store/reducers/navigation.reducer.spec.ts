import * as fromNavigation from './navigation.reducer';
import * as fromActions from '../actions/navigation.action';
import { Category } from '../../shared/models/category.model';

describe('NavigationReducer', () => {
  describe('undefined action', () => {
    it('should return the default state', () => {
      const { initialState } = fromNavigation;
      const action = {} as any;
      const state = fromNavigation.reducer(undefined, action);

      expect(state).toBe(initialState);
    });
  });

  describe('LOAD_NAVIGATION action', () => {
    it('should return the default state', () => {
      const { initialState } = fromNavigation;
      const action = new fromActions.LoadNavigation();
      const state = fromNavigation.reducer(initialState, action);

      expect(state.entities).toEqual({});
      expect(state.loaded).toEqual(false);
      expect(state.loading).toEqual(true);
    });
  });

  describe('LOAD_NAVIGATION_SUCCESS action', () => {
    it('should load the navigation', () => {
      const categories: Category[] = [
        {
          id: '1',
          name: 'Mens',
          createdOn: '2020-04-24T13:06:49.517Z',
          subcategories: [],
        },
        {
          id: '2',
          name: 'Womens',
          createdOn: '2019-04-24T13:06:49.517Z',
          subcategories: [],
        },
      ];

      const entities = {
        1: categories[0],
        2: categories[1],
      };

      const { initialState } = fromNavigation;
      const action = new fromActions.LoadNavigationSuccess(categories);
      const state = fromNavigation.reducer(initialState, action);

      expect(state.entities).toEqual(entities);
      expect(state.loaded).toEqual(true);
      expect(state.loading).toEqual(false);
    });
  });

  describe('LOAD_NAVIGATION_FAIL action', () => {
    it('should return the initial state', () => {
      const { initialState } = fromNavigation;
      const action = new fromActions.LoadNavigationFail({});
      const state = fromNavigation.reducer(initialState, action);

      expect(state).toEqual(initialState);
    });

    it('should return the previous state', () => {
      const { initialState } = fromNavigation;
      const previousState = { ...initialState, loading: true };
      const action = new fromActions.LoadNavigationFail({});
      const state = fromNavigation.reducer(previousState, action);

      expect(state).toEqual(initialState);
    });
  });
});

describe('NavigationReducers Selectors', () => {
  describe('getNavigationEntities', () => {
    it('should return entities prop', () => {
      const categories: Category[] = [
        {
          id: '1',
          name: 'Mens',
          createdOn: '2020-04-24T13:06:49.517Z',
          subcategories: [],
        },
        {
          id: '2',
          name: 'Kids',
          createdOn: '2019-04-24T13:06:49.517Z',
          subcategories: [],
        },
      ];

      const entities: { [key: string]: Category } = {
        1: categories[0],
        2: categories[1],
      };
      const { initialState } = fromNavigation;
      const previousState = { ...initialState, entities };
      const slice = fromNavigation.getNavigationEntities(previousState);

      expect(slice).toEqual(entities);
    });
  });

  describe('getNavigationLoading', () => {
    it('should return loading prop', () => {
      const { initialState } = fromNavigation;
      const previousState = { ...initialState, loading: true };
      const slice = fromNavigation.getNavigationLoading(previousState);

      expect(slice).toEqual(true);
    });
  });

  describe('getNavigationLoaded', () => {
    it('should return loaded prop', () => {
      const { initialState } = fromNavigation;
      const previousState = { ...initialState, loaded: true };
      const slice = fromNavigation.getNavigationLoaded(previousState);

      expect(slice).toEqual(true);
    });
  });
});
