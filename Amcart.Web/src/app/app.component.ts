import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { Router } from '../../node_modules/@angular/router';
import { OAuthService, JwksValidationHandler } from '../../node_modules/angular-oauth2-oidc';
import { isPlatformBrowser } from '../../node_modules/@angular/common';
import { authConfig } from './auth-config';
import { select, NgRedux } from '@angular-redux/store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  @select('Value') $selectedValue;
  @select('LastUpdate') $lastUpdate;
  constructor(private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object,
    private oauthService: OAuthService
    // private ngRedux:NgRedux<IAppState>
  ) {
      if (isPlatformBrowser(this.platformId)) {
        this.oauthService.configure(authConfig);
        this.oauthService.tokenValidationHandler = new JwksValidationHandler();
        this.oauthService.loadDiscoveryDocumentAndTryLogin();
      }
    }

  ngOnInit() {
    if (isPlatformBrowser(this.platformId)) {
      // this.ngRedux.dispatch({type:TEST_FIRST});
    }
  }
}
