// Decorators
import { Injectable } from '@angular/core';

// RXJS
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

// HTTP
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';

// Services
import { NotificationService } from '../services/notification.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private notificationService: NotificationService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        if (err.error instanceof ProgressEvent) {
          // A client-side or network error occurred
          this.notificationService.showNotification(
            'Network error!',
            null,
            'notification-danger'
          );
          console.log('Network error!');
        } else {
          // The backend returned an unsuccessful response code
          this.notificationService.showNotification(
            err.message,
            null,
            'notification-danger'
          );
          console.log(
            `${err.error.message} ${err.status.toString()} - ${err.statusText}`
          );
        }
        return throwError(err.error);
      })
    );
  }
}
