import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSongComponent } from './pages/add-song/add-song.component';

const routes: Routes = [
  {
    path: '',
    component: AddSongComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SongsRoutingModule { }
