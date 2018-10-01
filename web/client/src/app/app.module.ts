// CORE
import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router'

// 3rd PARTY
import {
  SocialLoginModule, 
  AuthServiceConfig,
  GoogleLoginProvider,
  FacebookLoginProvider,
  LinkedInLoginProvider
} from "angularx-social-login";

// MODULES
import { appRoutes }     from './app.routes';
import { AuthGuard } from './shared/common/auth/auth.guard';
import { AuthInterceptor } from './shared/common/auth/auth.interceptor';

// COMPONENT
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
import { UserComponent } from './public/pages/user/user.component';

//SERVICE
import { UserService } from './services/user/user.service';

const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('624796833023-clhjgupm0pu6vgga7k5i5bsfp6qp6egh.apps.googleusercontent.com')
  },
  // {
  //   id: FacebookLoginProvider.PROVIDER_ID,
  //   provider: new FacebookLoginProvider('561602290896109')
  // },
  // {
  //   id: LinkedInLoginProvider.PROVIDER_ID,
  //   provider: new LinkedInLoginProvider('78iqy5cu2e1fgr')
  // }
]); 

export function provideConfig() {
  return config;
} 
@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    SocialLoginModule,
    RouterModule.forRoot(appRoutes)
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
    SignupComponent,
    UserComponent
  ],
  providers: [
    UserService,
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    },
    AuthGuard,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
