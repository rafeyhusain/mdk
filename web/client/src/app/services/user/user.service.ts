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

  signup(email: string) {
    const url = `${ environment.apiUrl }/api/user/signup`;

    const body: any = {
      Email: email
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

  setUser(user: object) {
    if (user == null) {
      return;
    }
    
    localStorage.setItem('token', user['token']);
    localStorage.setItem('name', user['name']);
    localStorage.setItem('social', "false");
  }

  setSocialUser(user: object) {
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

  removeUser() {
    localStorage.removeItem('token');
    localStorage.removeItem('name');
    localStorage.removeItem('social');
  }

  isAuthenticated() {
    return this.getToken() != null;
  }

  isSocial() {
    return localStorage.getItem('social') == "true";
  }
}
