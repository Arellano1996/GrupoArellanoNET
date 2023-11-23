import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { AlertNotificationsService } from 'src/app/shared/alert-notifications/alert-notifications.service';
import { NotificationType } from 'src/app/shared/alert-notifications/interfaces/alert-notification.interface';
import { Line, _Chord } from './interfaces/song.interfaces';

@Component({
  selector: 'app-step-two-add-song-desktop',
  templateUrl: './step-two-add-song-desktop.component.html',
  styleUrls: ['./step-two-add-song-desktop.component.css']
})
export class StepTwoAddSongDesktopComponent {

  private notificationService = inject(AlertNotificationsService);

  @Input() song: string[] = [];//Letra desde el padre
  @Output() step = new EventEmitter<{ step: number, song: string[] }>();//controlar errores

  words: Array<Line>[] = [] || undefined;



  ngOnInit() {
    //Cuando el componente hijo hace un cambio al DOM debe hacerse en este punto
    //Y el setTimeout permite a Angular a terminar el ciclo de detección de cambios
    setTimeout(() => {
      //Se supone que esto nunca debería pasar, pero si se recibe una letra vacía marcar un error
      //console.log( this.song )
      if (this.song.length === 0) {

        this.notificationService.showAlert(NotificationType.Error, 'Texto vacío', 3000);

        setTimeout(() => {//Visualizamos el componente por 1 segundo
          this.step.emit({ step: 1, song: [] });//Regresar al paso 1
        }, 1000);

      } else {
        this.song.forEach((line, i) => {
          const words = line.split(' '); // Dividir cada string en palabras
          //console.log(`Words in line ${i}:`, words); // Imprimir las palabras de cada string con el índice
          this.words.push([]);//Agregamos renglon o line
          words.forEach((word, y) => {
            //console.log( word, y )
            this.words[i][y] = { word, toShow: false }; //Despues agregamos el contenido del renglon o line
          });
        });

        //console.log('Resultado:', this.words );
      }

    }, 0)
  }

  toBack() {
    this.step.emit({ step: 1, song: this.song });//Regresar al paso 1
  }

  clickOnWord(row: number, word: number) {
    console.log(row, word)
    this.words[row][word].toShow = !this.words[row][word].toShow ;
  }
  next() { }

}
