import { Routes } from '@angular/router'
import { HomeComponent } from  './public/pages/home/home.component';
import { UserComponent } from './public/pages/user/user.component';
import { SigninComponent } from './public/pages/secure/signin/signin.component';
import { SignupComponent } from './public/pages/signup/signup.component';
import { AuthGuard } from './shared/common/auth/auth.guard';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent,canActivate:[AuthGuard] },
    {
        path: 'signup', component: UserComponent,
        children: [{ path: '', component: SignupComponent }]
    },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: SigninComponent }]
    },
    { path : '', redirectTo:'/login', pathMatch : 'full'}
    
];