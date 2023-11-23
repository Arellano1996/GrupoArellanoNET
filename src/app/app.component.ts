import { Component, inject } from '@angular/core';
import { AlertNotificationsService } from './shared/alert-notifications/alert-notifications.service';
import { AlertNotification, NotificationType } from './shared/alert-notifications/interfaces/alert-notification.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'GrupoArellano';


  showAlert: boolean = false;

  alertNotification: AlertNotification = {
    notificationType: NotificationType.Success,
    message: '',
    time: 0
  }


  private notificationService = inject(AlertNotificationsService);

  ngOnInit(){

    this.notificationService.alert$.subscribe(
      ( res: any ) => {
      //console.log( res );
      //Copia la información necesaria para mostrar el mensaje
      this.alertNotification = res;
      //Activamos el mensaje
      this.showAlert = true;

      //Timer para ocultar el mensaje
      setTimeout( () => {
        this.showAlert = false;
      }, this.alertNotification.time);

    })

  }

}
