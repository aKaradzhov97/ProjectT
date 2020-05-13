import * as fromProducts from '../actions/products.action';
import { Product } from '../../../../shared/models/product.model';

export interface ProductState {
  entities: { [id: string]: Product };
  ids: string[];
  newest: { [id: string]: Product };
  trending: { [id: string]: Product };
  selectedProduct: Product;
  loaded: boolean;
  loading: boolean;
}

export const initialState: ProductState = {
  entities: {},
  ids: [],
  newest: {},
  trending: {},
  selectedProduct: null,
  loaded: false,
  loading: false,
};

export function reducer(
  state = initialState,
  action: fromProducts.ProductsAction
): ProductState {
  switch (action.type) {
    case fromProducts.LOAD_PRODUCTS:
    case fromProducts.LOAD_PRODUCTS_HOME: {
      return {
        ...state,
        loading: true,
      };
    }

    case fromProducts.LOAD_PRODUCTS_HOME_SUCCESS: {
      const trending = action.payload.data.trending.reduce(
        (trending: { [id: string]: Product }, product: Product) => {
          return {
            ...trending,
            [product.id]: product,
          };
        },
        {
          ...state.trending,
        }
      );

      const newest = action.payload.data.newest.reduce(
        (newest: { [id: string]: Product }, product: Product) => {
          return {
            ...newest,
            [product.id]: product,
          };
        },
        {
          ...state.newest,
        }
      );

      return {
        ...state,
        loading: false,
        loaded: true,
        newest,
        trending,
        entities: {
          ...state.entities,
          ...newest,
          ...trending,
        },
      };
    }

    case fromProducts.LOAD_PRODUCTS_SUCCESS: {
      const products = action.payload.data;

      const entities = products.reduce(
        (entities: { [id: string]: Product }, product: Product) => {
          return {
            ...entities,
            [product.id]: product,
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

    case fromProducts.LOAD_PRODUCTS_FAIL:
    case fromProducts.LOAD_PRODUCTS_HOME_FAIL: {
      return {
        ...state,
        loading: false,
        loaded: false,
      };
    }
  }

  return state;
}

export const getTrendingProductsEntities = (state: ProductState) =>
  state.trending;
export const getNewestProductsEntities = (state: ProductState) => state.newest;
export const getProductsEntities = (state: ProductState) => state.entities;
export const getProductsLoading = (state: ProductState) => state.loading;
export const getProductsLoaded = (state: ProductState) => state.loaded;
