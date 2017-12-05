import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";
import { AuthToken } from "../users/models/AuthToken";
import { retry } from "rxjs/operators/retry";


@Injectable()
export class AuthService  {

  token: AuthToken
  constructor() {}

  getToken() : AuthToken {
      return this.token
  }

  setToken(token :AuthToken) :void {
        this.token = token

        console.log(this.token)
    }
}

