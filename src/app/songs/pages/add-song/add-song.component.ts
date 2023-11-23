import { Component, ElementRef, HostListener, ViewChild } from '@angular/core';

@Component({
  selector: 'app-add-song',
  templateUrl: './add-song.component.html',
  styleUrls: ['./add-song.component.css']
})
export class AddSongComponent {

// desktopMode = true;
song: string[] = [];
step = 1;

getSongFromChildren(e: string[]){
  //Este evento es emitido por el child stepOne
  //Se recibe la letra en forma de arreglo
  if( e.length > 0){
    //console.log( e.length );
    this.song = e;
    this.step = 2;
  }
}

handleChildStepTwo(e: { step: number, song: string[] }){

  this.step = e.step;

  if( this.song.length > 0 ) {
    this.song = e.song;
    console.log( e.song );
  }

}

}
