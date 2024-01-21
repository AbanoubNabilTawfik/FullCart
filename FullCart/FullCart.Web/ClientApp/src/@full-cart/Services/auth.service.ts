import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserDetailsDto } from '../Models/Security/user';
import { Router } from '@angular/router';
import { HttpService } from './http.service';
import { login } from '../Models/auth/login';
import { SecurityController } from '../APIs/SecurityController';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user: any;
  public isLoggedInVar: boolean = false;

  // logged in user
  public loggedInUser$: BehaviorSubject<UserDetailsDto> =
    new BehaviorSubject<UserDetailsDto>(new UserDetailsDto());

  // loadingAction
  public loadingAction$: BehaviorSubject<Boolean> =
    new BehaviorSubject<Boolean>(false);

  constructor(private router: Router, private HttpService: HttpService) {
    this.user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    if (this.user != null) {
      this.loggedInUser$.next(this.user);
      this.loadingAction$.next(false);
    }
  }

  // store user data after login succeffully
  updateStoredUserInfo(userData: any) {
    let user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    user.firstName = userData && userData.firstName ? userData.firstName : null;
    user.lastName = userData && userData.lastName ? userData.lastName : null;
    user.phoneNumber =
      userData && userData.phoneNumber ? userData.phoneNumber : null;
    if (userData.personalImagePath) {
      user.personalImagePath = userData.personalImagePath;
    }
    localStorage.setItem('ecommerce_user', JSON.stringify(user));

    this.loggedInUser$.next(user);
  }

  updateStoredUserRoles(roles: string[]) {
    let user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    user.userRoles = roles;
    localStorage.setItem('ecommerce_user', JSON.stringify(user));
    this.loggedInUser$.next(user);
  }

  refreshToken(token: string) {
    let user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    user.token = 'Bearer ' + token;
    localStorage.setItem('ecommerce_user', JSON.stringify(user));
    this.loggedInUser$.next(user);
  }

  // store user data after login succeffully
  storeUserDate(user: any) {
    // local storage store only string, so need to convert json data to string
    // JSON.parse(user), to return user to an normal object
    user.is_token_expired = false;
    user.token = 'Bearer ' + user.token;
    localStorage.setItem('ecommerce_user', JSON.stringify(user));

    this.loggedInUser$.next(
      JSON.parse(localStorage.getItem('ecommerce_user') || '{}')
    );
  }

  // load the data
  loadToken() {
    if (
      localStorage.getItem('user') &&
      JSON.parse(localStorage.getItem('ecommerce_user') || '{}').token
    ) {
      this.user = JSON.parse(localStorage.getItem('ecommerce_user') || '{}');
    }
  }

  // loading action
  ActionLoading(val: boolean) {
    this.loadingAction$.next(Boolean(val));
  }

  Login(model: login) {
    return this.HttpService.POST(SecurityController.Login, model);
  }
  logout() {
    this.user = null;
    localStorage.removeItem('ecommerce_user');
    localStorage.removeItem('Role');
    localStorage.removeItem('email');
    this.router.navigate(['/auth/login']);
    this.isLoggedInVar = false;

  }

  loginAsync() {
    this.isLoggedInVar = true;
  }


  // Method to check if the user is logged in
  isLoggedIn(): boolean {
    return this.isLoggedInVar;
  }
}