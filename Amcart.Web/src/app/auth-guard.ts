import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRoute } from '@angular/router';
import { OAuthService } from "angular-oauth2-oidc";

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private oauthService: OAuthService,private route: ActivatedRoute, private router: Router) { }

    canActivate() {
        if (this.oauthService.hasValidAccessToken()) {
            return true;
        }
        else {
            this.oauthService.initImplicitFlow();
        }
    }
}