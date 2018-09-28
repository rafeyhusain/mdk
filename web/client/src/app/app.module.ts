import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';

import { AppRoutingModule }     from './app-routing.module';
import { OAuthModule } from 'angular-oauth2-oidc';

import { AppComponent }         from './app.component';
import { CarComponent } from './public/components/car/car.component';
import { CarListComponent } from './public/components/car-list/car-list.component';
import { CarDetailComponent } from './public/components/car-detail/car-detail.component';
import { HomeComponent } from  './public/pages/home/home.component';
import { CarFilterComponent } from './public/components/car-filter/car-filter.component';
import { PagerComponent } from './public/components/pager/pager.component';
import { FilterCheckboxComponent } from './public/components/filter-checkbox/filter-checkbox.component';
import { FilterSliderComponent } from './public/components/filter-slider/filter-slider.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    OAuthModule.forRoot()
  ],
  declarations: [
    AppComponent,
    CarComponent,
    CarListComponent,
    CarDetailComponent,
    HomeComponent,
    CarFilterComponent,
    PagerComponent,
    FilterCheckboxComponent,
    FilterSliderComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }

