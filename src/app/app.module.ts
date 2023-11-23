import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './shared/nav/nav.component';
import { BackgroundComponent } from './shared/background/background.component';
import { AlertNotificationsComponent } from './shared/alert-notifications/alert-notifications.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BackgroundComponent,
    AlertNotificationsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
