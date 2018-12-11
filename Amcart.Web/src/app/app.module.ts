import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { OAuthModule } from 'angular-oauth2-oidc';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HttpClientModule } from '../../node_modules/@angular/common/http';
import { routes } from './app-routes';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth-guard';
import { ProfileComponent } from './profile/profile.component';
// import { IAppState, rootReducer, INITIAL_STATE } from './store/store';
// import { NgRedux, NgReduxModule } from '@angular-redux/store'
// import { AjaxModule } from 'utility/ajax'
import { HeaderModule } from './header/header.module';
import { NavbarModule } from './navbar/navbar.module';
import { FooterModule } from './footer/footer.module';
import { LoginRegisterModule } from './login-register/login-register.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent
  ],
  imports: [
    HttpClientModule,
    // OAuthModule.forRoot(),
    RouterModule.forRoot(routes),
    BrowserModule,
    // NgReduxModule,
    HeaderModule,
    NavbarModule,
    FooterModule,
    LoginRegisterModule
  ],
  providers: [
    // AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  // constructor(ngRedux: NgRedux<IAppState>) {
  //   ngRedux.configureStore(rootReducer, INITIAL_STATE);
  // }
}
