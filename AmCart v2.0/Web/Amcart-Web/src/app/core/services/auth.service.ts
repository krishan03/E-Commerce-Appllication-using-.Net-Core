import { Injectable } from '@angular/core';
import { UserManager, User, Log } from 'oidc-client';
import { Constants } from '../../app-settings';
import { CustomerService } from './customer.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userManager: UserManager;
  user: User;

  constructor(private customerService: CustomerService) {
    Log.logger = console;
    var settings = {
      authority: Constants.AppConstants.stsAuthority,//Constants.stsAuthority,
      client_id: Constants.AppConstants.clientId,
      redirect_uri: `${Constants.AppConstants.clientRoot}login-callback`,
      post_logout_redirect_uri: `${Constants.AppConstants.clientRoot}logout-callback`,
      response_type: 'id_token token',
      scope: Constants.AppConstants.clientScope,
      automaticSilentRenew: true,
      silent_redirect_uri: `${Constants.AppConstants.clientRoot}silent-callback`
    };
    this.userManager = new UserManager(settings);

    this.userManager.getUser().then(user => {
      if (user && !user.expired) {
        this.user = user;
        this.customerService.loadCustomerContext();
      }
    });

    this.userManager.events.addUserLoaded(() => {
      this.userManager.getUser().then(user => {
        this.user = user;
        this.customerService.loadCustomerContext();
      });
    });
  }

  redirectToLogin(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  loginCallback(): Promise<User> {
    return this.userManager.signinRedirectCallback();
  }

  silentCallback(): Promise<any> {
    return this.userManager.signinSilentCallback();
  }

  redirectToLogout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  logoutCallback(): Promise<User> {
    return this.userManager.signoutRedirectCallback();
  }

  refreshToken(): Promise<User> {
    return this.userManager.signinSilent();
  }

  getUserDetails(): Promise<User> {
    return this.userManager.getUser();
  }

  isLoggedIn(): boolean {
    return this.user && this.user.access_token && !this.user.expired;
  }

  getAccessToken(): string {
    return this.user ? this.user.access_token : '';
  }
}
