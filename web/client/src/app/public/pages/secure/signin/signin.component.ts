import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse, HttpRequest, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import {
    FormGroup,
    FormBuilder,
    Validators,
    FormControl
} from '@angular/forms';

import {
    AuthService,
    SocialUser,
    GoogleLoginProvider,
    FacebookLoginProvider,
    LinkedInLoginProvider
} from "angularx-social-login";

import { UserService } from '../../../../services/user/user.service';
import { MessageService } from '../../../../services/message/message.service';
import { Http } from '@angular/http';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
    user: SocialUser;
    form: FormGroup;
    err: HttpErrorResponse;

    constructor(
        private userService : UserService,
        private router : Router,
        private authService: AuthService,
        private formBuilder: FormBuilder,
        private messageService: MessageService) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
            password: ['', [Validators.required]]
        });

        this.authService.authState.subscribe((user) => {
            this.user = user;
            this.userService.setSocialUser(user);
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
      
    get f() { return this.form.controls; }

    onSubmit(){
        if (this.form.invalid) {
            return;
        }

        this.userService.signin(this.f.email.value, this.f.password.value).subscribe((user : any)=>{
            this.userService.setUser(user);
            this.router.navigate(['/home']);
       },
       (err : HttpErrorResponse)=>{
           this.err = err;
       });
     }
}