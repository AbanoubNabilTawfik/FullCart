import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanLoad, Route, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate, CanLoad {

  canLoad(route: Route): boolean {


    const user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    if (user && user.accessToken) {
      console.log('authorized');

      return true;
    } else {
      this.router.navigate(['auth/login']);
      console.log('un authorized');

      return false;
    }
  }

  constructor(
    private router: Router,

  ) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {


    const user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    if (user && user.accessToken) {
      return true;
    } else {
      this.router.navigate(['auth/login']);
      return false;
    }
  }
}
