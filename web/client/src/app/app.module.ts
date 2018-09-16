import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CarComponent } from './public/components/car/car.component';
import { CarListComponent } from './public/components/car-list/car-list.component';
import { CarDetailComponent } from './public/components/car-detail/car-detail.component';
import { HomeComponent } from  './public/pages/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    CarComponent,
    CarListComponent,
    CarDetailComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
