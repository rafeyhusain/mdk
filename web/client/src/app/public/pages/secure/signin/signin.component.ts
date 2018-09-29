import { Component, OnInit } from '@angular/core';

import { AuthService } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider, LinkedInLoginProvider } from "angularx-social-login";
import { SocialUser } from "angularx-social-login";

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
    private user: SocialUser;
    private loggedIn: boolean;

    constructor(private authService: AuthService) { }

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
}