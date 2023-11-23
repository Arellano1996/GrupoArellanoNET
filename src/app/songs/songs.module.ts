import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SongsRoutingModule } from './songs-routing.module';
import { PlaylistComponent } from './layouts/playlist/playlist.component';
import { AddSongComponent } from './pages/add-song/add-song.component';
import { FormsModule } from '@angular/forms';
import { StepOneAddSongComponent } from './pages/add-song/layouts/step-one-add-song/step-one-add-song.component';
import { StepTwoAddSongComponent } from './pages/add-song/layouts/step-two-add-song/step-two-add-song.component';
import { StepTwoAddSongDesktopComponent } from './layouts/step-two-add-song-desktop/step-two-add-song-desktop.component';


@NgModule({
  declarations: [
    PlaylistComponent,
    AddSongComponent,
    StepOneAddSongComponent,
    StepTwoAddSongComponent,
    StepTwoAddSongDesktopComponent
  ],
  imports: [
    CommonModule,
    SongsRoutingModule,
    FormsModule
  ]
})
export class SongsModule { }
