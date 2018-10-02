import { Routes } from '@angular/router'
import { UserProfileComponent } from  './public/pages/user-profile/user-profile.component';
import { UserComponent } from './public/pages/user/user.component';
import { SigninComponent } from './public/pages/secure/signin/signin.component';
import { SignupComponent } from './public/pages/signup/signup.component';
import { AuthGuard } from './shared/common/auth/auth.guard';

export const appRoutes: Routes = [
    { path: 'user-profile', component: UserProfileComponent, canActivate:[AuthGuard] },
    {
        path: 'signup', component: UserComponent,
        children: [{ path: '', component: SignupComponent }]
    },
    {
        path: 'signin', component: UserComponent,
        children: [{ path: '', component: SigninComponent }]
    },
    { path : '', redirectTo:'/signin', pathMatch : 'full'}
];
