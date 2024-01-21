import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  constructor() {
    // Configure alertify settings if needed
    alertify.defaults.theme.ok = 'btn btn-success';
    alertify.defaults.theme.cancel = 'btn btn-danger';
  }

  showSuccess(message: string) {
    alertify.success(message);
  }

  showError(message: string) {
    alertify.error(message);
  }

  showWarning(message: string) {
    alertify.warning(message);
  }

  showInfo(message: string) {
    alertify.message(message);
  }

  // You can add more methods for different alert types or customize further
}
