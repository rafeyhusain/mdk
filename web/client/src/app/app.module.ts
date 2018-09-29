import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';

import { AppRoutingModule }     from './app-routing.module';

import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider, FacebookLoginProvider, LinkedInLoginProvider} from "angularx-social-login";

import { AppComponent }         from './app.component';
import { CarComponent } from './public/components/car/car.component';
import { CarListComponent } from './public/components/car-list/car-list.component';
import { CarDetailComponent } from './public/components/car-detail/car-detail.component';
import { HomeComponent } from  './public/pages/home/home.component';
import { CarFilterComponent } from './public/components/car-filter/car-filter.component';
import { PagerComponent } from './public/components/pager/pager.component';
import { FilterCheckboxComponent } from './public/components/filter-checkbox/filter-checkbox.component';
import { FilterSliderComponent } from './public/components/filter-slider/filter-slider.component';
import { SigninComponent } from './public/pages/secure/signin/signin.component';
import { SignupComponent } from './public/pages/signup/signup.component';

const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('624796833023-clhjgupm0pu6vgga7k5i5bsfp6qp6egh.apps.googleusercontent.com')
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider('561602290896109')
  },
  {
    id: LinkedInLoginProvider.PROVIDER_ID,
    provider: new LinkedInLoginProvider('78iqy5cu2e1fgr')
  }
]); 

export function provideConfig() {
  return config;
}
@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    SocialLoginModule
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
    FilterSliderComponent,
    SigninComponent,
    SignupComponent
  ],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    }
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
