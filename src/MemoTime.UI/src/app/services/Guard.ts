import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";
import { AuthService } from "./auth.service";


@Injectable()
export class Guard implements CanActivate {

  constructor(protected router: Router, private auth: AuthService) {}

  canActivate() {
    // if (localStorage.getItem('access_token')) {
    //   // logged in so return true
    //   return true;
    // }

    let token = this.auth.getToken();
    if (token)
    {
      
      return true
    }
    // not logged in so redirect to login page
    this.router.navigate(['home']);
    return false;
  }
}
