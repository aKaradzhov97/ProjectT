// Decorators
import { Injectable } from '@angular/core';

// Snackbar
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class NotificationService {
  constructor(private snackBar: MatSnackBar) {}

  showNotification(
    message: string,
    action: string = null,
    className: string = null
  ) {
    this.snackBar.open(message, (action = null), {
      duration: 3000,
      verticalPosition: 'bottom',
      horizontalPosition: 'center',
      panelClass: [className],
    });
  }
}
