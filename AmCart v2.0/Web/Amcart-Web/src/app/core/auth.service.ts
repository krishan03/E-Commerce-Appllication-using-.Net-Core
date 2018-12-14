import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { Constants } from '../app-settings';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userManager: UserManager;
  user: User;

  constructor() {
    var settings = {
      authority: Constants.stsAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}login-callback`,
      post_logout_redirect_uri: `${Constants.clientRoot}logout-callback`,
      response_type: 'id_token token',
      scope: Constants.clientScope
    };
    this.userManager = new UserManager(settings);

    this.userManager.getUser().then(user => {
      if(user && !user.expired) {
        this.user = user;
      }
    })
  }
  
  public redirectToLogin(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public loginCallback(): Promise<User> {
    return this.userManager.signinRedirectCallback();
  }
  
  public redirectToLogout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public logoutCallback(): Promise<User> {
    return this.userManager.signoutRedirectCallback();
  }
  
  public refreshToken(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public getUserDetails(): Promise<User> {
    return this.userManager.getUser();
  }

  public storeUserDetails(user: User) {
    this.user = user;
  }

  public isLoggedIn(): boolean {
    return this.user && this.user.access_token && !this.user.expired;
  }

  public getAccessToken(): string {
    return this.user ? this.user.access_token : '';
  }
}
