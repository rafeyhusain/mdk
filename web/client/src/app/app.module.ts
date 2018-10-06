// CORE
import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule }    from '@angular/forms';
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

//SERVICE
import { UserService } from './services/user/user.service';

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
import { SigninNavComponent } from './public/components/signin-nav/signin-nav.component';
import { UserProfileComponent } from './public/pages/user-profile/user-profile.component';
import { HeaderComponent } from './public/components/header/header.component';
import { FooterComponent } from './public/components/footer/footer.component';
import { MasterComponent } from './public/components/master/master.component';
import { SignupDoneComponent } from './public/pages/signup-done/signup-done.component';
import { PageNotFoundComponent } from './public/pages/page-not-found/page-not-found.component';

const config1 = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('624796833023-clhjgupm0pu6vgga7k5i5bsfp6qp6egh.apps.googleusercontent.com')
  }
]); 

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
  return config1;
} 

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
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
    UserComponent,
    SigninNavComponent,
    UserProfileComponent,
    HeaderComponent,
    FooterComponent,
    MasterComponent,
    SignupDoneComponent,
    PageNotFoundComponent
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
    }
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
