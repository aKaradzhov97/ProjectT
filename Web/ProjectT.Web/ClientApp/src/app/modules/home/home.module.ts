// Decorators
import { NgModule } from '@angular/core';

// NGRX & Store
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers, effects } from './store';

// Modules
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HomeRoutingModule } from './home-routing.module';
import { MaterialModule } from '../material/material.module';
import { GalleryModule } from '@ks89/angular-modal-gallery';

// Guards
import * as fromGuards from './guards';

// Services
import { ProductService } from '../../core/services/product.service';

// Components
import { HomeComponent } from './containers/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { ProductsListComponent } from './components/products-list/products-list.component';
import { ProductsListItemComponent } from './components/products-list-item/products-list-item.component';
import { DetailsProductComponent } from './containers/details-product/details-product.component';
import { DetailsProductItemComponent } from './components/details-product-item/details-product-item.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    HomeComponent,
    ProductsComponent,
    ProductsListComponent,
    ProductsListItemComponent,
    DetailsProductComponent,
    DetailsProductItemComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HomeRoutingModule,
    MaterialModule,
    GalleryModule,
    StoreModule.forFeature('products', reducers),
    EffectsModule.forFeature(effects),
    SharedModule,
  ],
  providers: [ProductService, fromGuards.guards],
})
export class HomeModule {}
