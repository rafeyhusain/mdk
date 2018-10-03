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
    user: SocialUser;
    userName: string;
    password: string;

    constructor(
        private userService : UserService,
        private router : Router,
        private authService: AuthService) { }

    ngOnInit() {
        this.userName = 'admin';
        this.password = 'admin';

        this.authService.authState.subscribe((user) => {
            this.user = user;
            this.userService.setTokenForSocialUser(user);
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
      
    onSubmit(){
        this.userService.signin(this.userName, this.password).subscribe((user : any)=>{
            this.userService.setToken(user);
            this.router.navigate(['/home']);
       },
       (err : HttpErrorResponse)=>{
           console.error('SignIn Error', err);
       });
     }
}
