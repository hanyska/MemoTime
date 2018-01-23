import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";
import { retry } from "rxjs/operators/retry";
import {AuthToken} from "../models/AuthToken";


@Injectable()
export class AuthService  {
  constructor() {}

  getToken() : string {
      let savedToken = localStorage.getItem("auth-token")
      if (savedToken == null)
      {
          return null;
      }

      return savedToken;
  }

  setToken(token :AuthToken) :void {
        localStorage.setItem("auth-token", token.token);
    }

  removeToken(): void {
      localStorage.removeItem("auth-token")
  }
}

