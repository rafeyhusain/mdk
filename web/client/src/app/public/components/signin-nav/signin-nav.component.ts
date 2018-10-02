import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../../services/user/user.service';

@Component({
  selector: 'app-signin-nav',
  templateUrl: './signin-nav.component.html',
  styleUrls: ['./signin-nav.component.css']
})
export class SigninNavComponent implements OnInit {
  userClaims: any;

  constructor(private router: Router, private userService: UserService) { }

  ngOnInit() {
    this.userService.getUserClaims().subscribe((data: any) => {
      this.userClaims = data;
    });
  }

  signIn() {
    this.router.navigate(['/signin']);
  }

  signOut() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/signin']);
  }
}
