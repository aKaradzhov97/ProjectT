// Decorators
import { NgModule } from '@angular/core';

// Gallery Module dependencies
import 'hammerjs';
import 'mousetrap';

// Modules
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@layout/layout.module';
import { SharedModule } from '@shared/shared.module';
import { MaterialModule } from '@material/material.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { EffectsModule } from '@ngrx/effects';
import { MetaReducer, StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { GalleryModule } from '@ks89/angular-modal-gallery';

// Store
import { reducers, effects, CustomSerializer } from './store';
import {
  StoreRouterConnectingModule,
  RouterStateSerializer,
} from '@ngrx/router-store';

// Interceptors
import { HTTPInterceptor } from './core/interceptors/http.interceptor';
import { SuccessInterceptor } from './core/interceptors/success.interceptor';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';

// Components
import { AppComponent } from './app.component';

// Services
import { NotificationService } from '@services/notification.service';

// Others
import { environment } from '../environments/environment';
import { PLATFORM_ID, APP_ID, Inject } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

export const metaReducers: MetaReducer<any>[] = [];

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    LoadingBarHttpClientModule,
    LayoutModule,
    SharedModule,
    MaterialModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    environment.production ? [] : StoreDevtoolsModule.instrument(),
    EffectsModule.forRoot(effects),
    StoreRouterConnectingModule.forRoot(),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
    }),
    GalleryModule.forRoot(),
  ],
  providers: [
    NotificationService,
    {
      provide: RouterStateSerializer,
      useClass: CustomSerializer,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HTTPInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SuccessInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(
    @Inject(PLATFORM_ID) private platformId: Object,
    @Inject(APP_ID) private appId: string
  ) {
    const platform = isPlatformBrowser(platformId)
      ? 'in the browser'
      : 'on the server';
    console.log(`Running ${platform} with appId=${appId}`);
  }
}
