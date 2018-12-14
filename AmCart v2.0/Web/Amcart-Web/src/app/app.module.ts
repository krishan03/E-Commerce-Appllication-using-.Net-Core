import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AuthService } from './core/auth.service';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { HttpService } from './core/http.service';
import { RouterModule } from '@angular/router';
import { ApplicationRoutes } from './app-routes';
import { HttpClientModule } from '@angular/common/http';
import { CustomerModule } from './customer/customer.module';
import { ProductModule } from './product/product.module';
import { AuthModule } from './auth/auth.module';
import { MainComponent } from './main/main.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    MainComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    RouterModule.forRoot(ApplicationRoutes),
    CustomerModule,
    ProductModule,
    AuthModule
  ],
  providers: [
    AuthService,
    HttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
