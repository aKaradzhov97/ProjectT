// Decorators
import { Injectable } from '@angular/core';

// RXJS
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

// HTTP
import {
  HttpResponse,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';

// Services
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/notification.service';

@Injectable()
export class SuccessInterceptor implements HttpInterceptor {
  constructor(
    private notificationService: NotificationService,
    private authService: AuthService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      tap((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          if (event.body.message || event.body.message !== '') {
            this.notificationService.showNotification(
              event.body.message,
              null,
              'notification-success'
            );
          }
        }

        if (event instanceof HttpResponse && !!event.body.user) {
          this.authService.saveSession(event.body.user);
          this.authService.isUserLogged.next(true);

          console.log('Success! ' + event.body.message);
        }
      })
    );
  }
}
