import { Injectable } from '@angular/core';
import {User} from "../../sharded/models/User";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import {of} from "rxjs/observable/of";
import { retry } from 'rxjs/operators/retry';
import { AuthToken } from '../../sharded/models/AuthToken';

const
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

@Injectable()
export class UsersService {

  private registerUrl = 'http://localhost:5000/account'
  private loginUrl = 'http://localhost:5000/login'
  private logoutUrl = "http://localhost:5000/logout"

  private user: User;

  constructor(private http: HttpClient) {
  }

  registerUser(user: User): Observable<User>{
    return this.http.post(this.registerUrl, user, httpOptions)
  }

  loginUser(user: User): Observable<AuthToken>{
    return this.http.post(this.loginUrl, user, httpOptions)
  }

  logoutUser(): Observable<Response> {
    return this.http.post(this.logoutUrl, null, this.http)
  }
}
