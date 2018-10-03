import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

import { User } from '../../shared/models/user.model';
import { MessageService } from '../message/message.service';
 
@Injectable()
export class UserService {

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  registerUser(user: User) {
    const url = `${ environment.apiUrl }/api/user/register`;

    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }

    var options = { headers : new HttpHeaders({'No-Auth':'True'}) };
    
    return this.http.post(url, body, options);
  }

  signin(userName, password) {
    const url = `${ environment.apiUrl }/api/user/token`;

    var body = `username=${ userName }&password=${ password }&grant_type=password`;
    var options = { headers : new HttpHeaders(
      { 
        'Content-Type': 'application/x-www-urlencoded',
        'No-Auth':'True'
      })
    };

    return this.http.post(url, body, options);
  }

  getUserClaims():Observable<any> {
    const url = `${ environment.apiUrl }/api/user/claims`;

    var options = { headers : new HttpHeaders({'No-Auth':'True'}) };

    return this.http.get<any>(url, options).pipe(
      tap((result: any) => {
      }),
      catchError(this.messageService.error<any>(`getUserClaims`))
    );
  }

  setToken(user: object) {
    if (user == null) {
      return;
    }
    
    localStorage.setItem('token', user['token']);
    localStorage.setItem('name', user['name']);
    localStorage.setItem('social', "false");
  }

  setTokenForSocialUser(user: object) {
    if (user == null) {
      return;
    }

    localStorage.setItem('token', user['authToken']);
    localStorage.setItem('name', user['firstName']);
    localStorage.setItem('social', "true");
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getName() {
    return localStorage.getItem('name');
  }

  removeToken() {
    localStorage.removeItem('token');
  }

  isAuthenticated() {
    return this.getToken() != null;
  }

  isSocial() {
    return localStorage.getItem('social') == "true";
  }
}
