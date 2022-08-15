import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
} from '@angular/router';
import { Injectable } from '@angular/core';
import { LoginService } from '../services/login.service';

@Injectable()
export class LoginGuard implements CanActivate {
  constructor(private authservice: LoginService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    let logged = this.authservice.checklogin();

    if (logged) {
      return true;
    }
    this.router.navigate(['']);
    return false;
  }
}
