import { Component, Input } from '@angular/core';
import { NotificationType } from './interfaces/alert-notification.interface';

@Component({
  selector: 'app-alert-notifications',
  templateUrl: './alert-notifications.component.html',
  styleUrls: ['./alert-notifications.component.css']
})
export class AlertNotificationsComponent {

  // success error warning
  @Input() notificationType: NotificationType = NotificationType.Success;
  @Input() message: string = '';

}
