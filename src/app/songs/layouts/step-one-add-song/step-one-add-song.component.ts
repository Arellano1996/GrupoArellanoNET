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
  selectionStart = 0;
  lyricsReady: string[] = [];
  secondDivMaxHeight = '';


  onKeyUp(event: KeyboardEvent) {

    if (event.key === 'Enter' && event.shiftKey) return;
    //Comprobar que la tecla tocada haya sido el Enter
    if (event.key != 'Enter') return;
    //console.log(' Enter detected ');
    //referencia
    const textareaElement = this.myTextarea.nativeElement;
    //Tomamos el texto y lo agregamos al arreglo de las letras listas
    const selectedText = textareaElement.value.substring(0, this.selectionStart).trimStart().trimEnd();
    //Aquí agregamos al arreglo de las letras listas si no esta vacío
    if (selectedText.length > 0) {
      this.lyricsReady.push(selectedText);
      //Eliminamos de nuestro textarea la letra que ya está lista
      textareaElement.value = textareaElement.value.substring(this.selectionStart);
    }
    // Eliminar los saltos de línea vacíos después de la eliminación
    const lines = textareaElement.value.split('\n');
    for (let i = 0; i < lines.length; i++) {
      if (lines[i].trim() === '') {
        lines.splice(i, 1);
        i--;
      }
    }
    textareaElement.value = lines.join('\n');

    //Reescalar al nuevo tamaño
    this.onInput();
    console.log(this.lyricsReady);

  }

  onMouseUp() {
    //referencia
    const textareaElement = this.myTextarea.nativeElement;
    //Detectar en que posicion quede en mi textarea cuando uso el mouse
    this.selectionStart = textareaElement.selectionStart;
    //const selectedText = textareaElement.value.substring(0, this.selectionStart);
    //console.log('Texto seleccionado:', selectedText);
  }

  onInput() {
    //referencia
    const textareaElement = this.myTextarea.nativeElement;
    // Ajustar la altura del textarea en base al contenido
    textareaElement.style.height = Math.min(textareaElement.scrollHeight, window.innerHeight * 0.35 ) + 'px';

    //Detectar en que posicion quede en mi textarea cuando uso el teclado
    this.selectionStart = textareaElement.selectionStart;

    const textareaHeight = this.myTextarea.nativeElement.clientHeight;
    //console.log( textareaHeight);
    this.secondDivMaxHeight = `${textareaHeight}px`;
  }

  regresarTextoAlTextarea(textoInicial: string) {
    if( textoInicial === '\n'){
      this.lyricsReady.pop();;
      return
    }
    const textoActual = this.myTextarea.nativeElement.value;
    this.myTextarea.nativeElement.value = textoInicial + '\n' + textoActual;
    this.lyricsReady.pop();
    this.onInput();
  }

  agregarEspacio(){
    this.lyricsReady.push('\n');
  }

  eliminarTodo(){
    this.lyricsReady = [];
    this.myTextarea.nativeElement.value = '';
  }

}
