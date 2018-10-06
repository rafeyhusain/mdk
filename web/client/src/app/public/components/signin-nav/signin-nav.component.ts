import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../../services/user/user.service';
import { AuthService } from 'angularx-social-login';

@Component({
  selector: 'app-signin-nav',
  templateUrl: './signin-nav.component.html',
  styleUrls: ['./signin-nav.component.css']
})
export class SigninNavComponent implements OnInit {
  constructor(
    private router: Router, 
    private userService: UserService,
    private authService: AuthService) { }

  ngOnInit() {
  }

  signOut() {
    if (this.userService.isSocial()) {
      this.authService.signOut();
    }
    this.userService.removeUser();
    this.router.navigate(['/signin']);
  }
}
