import * as fromNavigation from './navigation.action';

describe('Navigation Actions', () => {
  describe('LoadNavigation', () => {
    it('should create an action', () => {
      const action = new fromNavigation.LoadNavigation();

      expect({ ...action }).toEqual({
        type: fromNavigation.LOAD_NAVIGATION,
      });
    });
  });

  describe('LoadNavigationFail', () => {
    it('should create an action', () => {
      const payload = { message: 'Load Error' };
      const action = new fromNavigation.LoadNavigationFail(payload);

      expect({ ...action }).toEqual({
        type: fromNavigation.LOAD_NAVIGATION_FAIL,
        payload,
      });
    });
  });

  describe('LoadNavigationSuccess', () => {
    it('should create an action', () => {
      const payload = [{}];
      const action = new fromNavigation.LoadNavigationSuccess(payload);

      expect({ ...action }).toEqual({
        type: fromNavigation.LOAD_NAVIGATION_SUCCESS,
        payload,
      });
    });
  });
});
