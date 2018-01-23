import {CanActivate,  CanActivateChild, Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot,

} from "@angular/router";
import {Injectable} from "@angular/core";
import { AuthService } from "./auth.service";


@Injectable()
export class Guard implements CanActivate, CanActivateChild {

  constructor(protected router: Router, private auth: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let token = this.auth.getToken();
    if (token)
    {
      return true
    }

    this.router.navigate(['home']);

    return false;
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    return this.canActivate(route, state)
  }
}
