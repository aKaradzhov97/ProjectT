// Decorators
import { Injectable } from '@angular/core';

// RXJS
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

// HTTP
import { HttpClient } from '@angular/common/http';

// Models
import { Navigation } from '../../shared/models/navigation.model';

// Constants
import { API_CONSTANTS } from '../../shared/constants';

const BASE_URL = API_CONSTANTS.BASE_URL + API_CONSTANTS.NAVIGATION_ENDPOINT;

const GET_NAVIGATION_URL = `${BASE_URL}`;

@Injectable()
export class NavigationService {
  constructor(private http: HttpClient) {}

  getNavigation(): Observable<Navigation> {
    return this.http
      .get<Navigation>(GET_NAVIGATION_URL)
      .pipe(catchError((error: any) => Observable.throw(error.json())));
  }
}
