import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { Constants } from '../app-settings';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userManager: UserManager;

  constructor() {
    var settings = {
      authority: Constants.stsAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}login-callback`,
      silent_redirect_uri: `${Constants.clientRoot}logout-callback`,
      post_logout_redirect_uri: `${Constants.clientRoot}`,
      response_type: 'id_token token',
      scope: Constants.clientScope
    };
    this.userManager = new UserManager(settings);
  }
  
  public getUserDetails(): Promise<User> {
    return this.userManager.getUser();
  }

  public redirectToLogin(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public refreshToken(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }
}
