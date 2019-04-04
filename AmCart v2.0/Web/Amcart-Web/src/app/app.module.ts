import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { ApplicationRoutes } from './app-routes';
import { HttpClientModule } from '@angular/common/http';
import { CustomerModule } from './customer/customer.module';
import { ProductModule } from './product/product.module';
import { AuthModule } from './auth/auth.module';
import { MainComponent } from './main/main.component';
import { CoreModule } from './core/core.module';
import { CartPeekComponent } from './cart-peek/cart-peek.component';
import { FormsModule } from '@angular/forms';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AddProductComponent } from './add-product/add-product.component';
import { MultiSelectModule } from 'primeng/multiselect';
import {ChipsModule} from 'primeng/chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    MainComponent,
    CartPeekComponent,
    ContactUsComponent,
    AddProductComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    RouterModule.forRoot(ApplicationRoutes),
    CustomerModule,
    ProductModule,
    AuthModule,
    CoreModule,
    FormsModule,
    MultiSelectModule,
    BrowserAnimationsModule,
    ChipsModule
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
