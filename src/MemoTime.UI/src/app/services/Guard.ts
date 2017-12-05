import {CanActivate, Router} from "@angular/router";
import {Injectable} from "@angular/core";


@Injectable()
export class Guard implements CanActivate {

  constructor(protected router: Router) {}

  canActivate() {
    // if (localStorage.getItem('access_token')) {
    //   // logged in so return true
    //   return true;
    // }

    if (2 > 1)
    {
      return true
    }
    // not logged in so redirect to login page
    this.router.navigate(['/login']);
    return false;
  }
}
