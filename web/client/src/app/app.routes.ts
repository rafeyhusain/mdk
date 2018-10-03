import { Routes } from '@angular/router'
import { UserProfileComponent } from  './public/pages/user-profile/user-profile.component';
import { UserComponent } from './public/pages/user/user.component';
import { SigninComponent } from './public/pages/secure/signin/signin.component';
import { SignupComponent } from './public/pages/signup/signup.component';
import { AuthGuard } from './shared/common/auth/auth.guard';
import { HomeComponent } from './public/pages/home/home.component';
import { CarFilterComponent } from './public/components/car-filter/car-filter.component';

export const appRoutes: Routes = [
    { path: '', component: CarFilterComponent },
    { path: 'home', component: CarFilterComponent },
    { path: 'user-profile', component: UserProfileComponent, canActivate:[AuthGuard] },
    { path: 'signin', component: SigninComponent },
    { path: 'signup', component: SignupComponent },
];
