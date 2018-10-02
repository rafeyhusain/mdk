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
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(url, body,{headers : reqHeader});
  }

  signin(userName, password) {
    const url = `${ environment.apiUrl }/api/user/token`;

    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.http.post(url, data, { headers: reqHeader });
  }

  getUserClaims():Observable<any> {
    const url = `${ environment.apiUrl }/api/user/claims`;

    return this.http.get<any>(url).pipe(
      tap((result: any) => {
      }),
      catchError(this.messageService.error<any>(`getUserClaims`))
    );

    return this.http.get(environment.apiUrl+'/api/');
  }
}
