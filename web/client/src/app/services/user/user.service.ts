import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from '../../shared/models/user.model';
import { environment } from '../../../environments/environment';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(environment.apiUrl + '/api/User/Register', body,{headers : reqHeader});
  }

  signin(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.http.post(environment.apiUrl + '/token', data, { headers: reqHeader });
  }

  getUserClaims(){
   return  this.http.get(environment.apiUrl+'/api/GetUserClaims');
  }
}
