import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { UserService } from '../../../services/user/user.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router : Router, private userService: UserService) {}
  
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean {
      if (this.userService.isAuthenticated()) {
        console.log('[AuthGuard] Authenticated');
        return true;
      } else {
        console.log('[AuthGuard] You are not authorized.');
        this.router.navigate(['/signin']);
        return false;
      }
  }
}
