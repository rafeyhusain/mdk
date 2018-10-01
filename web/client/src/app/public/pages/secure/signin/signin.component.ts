import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import {
    AuthService,
    SocialUser,
    GoogleLoginProvider,
    FacebookLoginProvider,
    LinkedInLoginProvider
} from "angularx-social-login";

import { UserService } from '../../../../services/user/user.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
    private user: SocialUser;
    private loggedIn: boolean;

    constructor(private userService : UserService,
        private router : Router,
        private authService: AuthService) { }

    ngOnInit() {
        this.authService.authState.subscribe((user) => {
            this.user = user;
            this.loggedIn = (user != null);
        });
    }

    signInWithGoogle(): void {
        this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
    }

    signInWithFB(): void {
        this.authService.signIn(FacebookLoginProvider.PROVIDER_ID);
    }

    signInWithLinkedIn(): void {
        this.authService.signIn(LinkedInLoginProvider.PROVIDER_ID);
    }  

    signOut(): void {
        this.authService.signOut();
    }

    OnSubmit(userName,password){
        this.userService.signin(userName, password).subscribe((data : any)=>{
            this.loggedIn = (data.access_token != null);
            localStorage.setItem('userToken', data.access_token);
            this.router.navigate(['/home']);
       },
       (err : HttpErrorResponse)=>{
           console.error('SignIn Error', err);
       });
     }
}
