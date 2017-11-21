import { Injectable } from '@angular/core';
import {User} from "../models/User";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import { catchError, map, tap } from 'rxjs/operators';
import {of} from "rxjs/observable/of";

const
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  };

@Injectable()
export class UsersService {

  private userUrl = 'http://localhost:5000/account'

  private user: User;

  constructor(private http: HttpClient) {
  }

  registerUser(user: User): Observable<User>{
    return this.http.post(this.userUrl, user, httpOptions)
  }
}
