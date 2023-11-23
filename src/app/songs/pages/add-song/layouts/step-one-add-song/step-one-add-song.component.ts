import { Component, ElementRef, EventEmitter, Input, Output, ViewChild, inject } from '@angular/core';
import { AlertNotificationsService } from 'src/app/shared/alert-notifications/alert-notifications.service';
import { NotificationType } from 'src/app/shared/alert-notifications/interfaces/alert-notification.interface';

@Component({
  selector: 'app-step-one-add-song',
  templateUrl: './step-one-add-song.component.html',
  styleUrls: ['./step-one-add-song.component.css']
})
export class StepOneAddSongComponent {

  @ViewChild('myTextarea') myTextarea!: ElementRef<HTMLTextAreaElement>;
  sizeMode = false; // 0 desktop 1 mobile

  private notificationService = inject(AlertNotificationsService);

  @Output() readySong = new EventEmitter<string[]>();
  textareaContent: string = '';
  @Input() lines: string[] = [];

  switchSize() {
    console.log(this.sizeMode)
    this.sizeMode = !this.sizeMode;
    this.onInput();
  }

  onInput() {

    if (this.sizeMode) {
      //referencia
      const textareaElement = this.myTextarea.nativeElement;
      textareaElement.style.height = 'auto';
      textareaElement.style.height = textareaElement.scrollHeight + 'px';

    } else {
      //referencia
      const textareaElement = this.myTextarea.nativeElement;
      // Ajustar la altura del textarea en base al contenido
      textareaElement.style.height = Math.min(textareaElement.scrollHeight, window.innerHeight * 0.30) + 'px';

    }

  }

  onKeyUp(event: KeyboardEvent) {

    if (event.key === 'Enter' && event.ctrlKey) this.splitText();

  }

  eliminarTodo(){
    this.lines = [];
    this.textareaContent = ''
    this.myTextarea.nativeElement.value = '';
    this.onInput();
  }

  next(){

    this.splitText();

    //console.log( this.lines );
    if( this.lines.length === 0 ) {
      this.notificationService.showAlert( NotificationType.Error, 'No se ha agregado una letra', 3000);
      return;
    }

    if( this.lines[0].length > 0 ) this.readySong.emit( this.lines );

  }

  ngOnInit(){

    //Si recibes una letra del padre
    //*Esto ocurre cuando se pasa al paso 2 y desde el paso dos se regresa al paso 1
    //y se tiene que mantener la letra previamente editada
    //Si se inicia la aplicación por primera vez esto no se ejecuta
    setTimeout( () => {
      if( this.lines.length > 0 ){
        //console.log( this.lines );
        this.myTextarea.nativeElement.value = this.lines.join('\n');
        this.textareaContent = this.lines.join('\n');
        this.onInput();
      }
    }, 0)
  }

  splitText() {

    //console.log( this.textareaContent.trim().length )
    //Si el texto que se intenta guardar es un espacio en blanco, no agreges nada
    if( this.textareaContent.trim().length === 0 ||
    //Si el arreglo lines que guarda los parrafos está vacio
    //y si el renglon que se intenta guardar son espacios en blanco, no agreges nada
    ( this.lines.length === 0 && this.textareaContent.trim().length === 0 ) ){
      this.notificationService.showAlert( NotificationType.Warning, 'No hay ningún texto', 3000);
      return;
    }
    //if( this.lines.length === 0 ) return;
    this.lines = this.textareaContent.split('\n');
    //console.log( 'fin método ');
  }



}
