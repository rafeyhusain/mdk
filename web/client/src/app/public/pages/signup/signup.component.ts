import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import {
    FormGroup,
    FormBuilder,
    Validators,
    FormControl
} from '@angular/forms';

import { UserService } from '../../../services/user/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
    form: FormGroup;
    err: HttpErrorResponse;

    constructor(
        private userService : UserService,
        private router : Router,
        private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]]
        });
    }

    get f() { return this.form.controls; }

    onSubmit(){
        if (this.form.invalid) {
            return;
        }

        this.userService.signup(this.f.email.value).subscribe((user : any)=>{
            this.router.navigate(['/signup-done']);
       },
       (err : HttpErrorResponse)=>{
           this.err = err;
       });
     }
}
