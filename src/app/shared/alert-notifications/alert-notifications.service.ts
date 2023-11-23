import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AlertNotification, NotificationType } from './interfaces/alert-notification.interface';

@Injectable({
  providedIn: 'root'
})
export class AlertNotificationsService {

  private alertSource = new Subject();
  alert$ = this.alertSource.asObservable();

  showAlert(notificationType: NotificationType, message: string, time: number = 5000) {

    const alertNotification = {
      notificationType,
      message,
      time
    }
    this.alertSource.next( alertNotification );

  }

}
