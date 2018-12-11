import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRegisterComponent } from './login-register/login-register.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AccessTokenService } from '../services/access-token.service';
import { LocalStorageService } from '../services/local-storage.service';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [LoginRegisterComponent],
  exports: [LoginRegisterComponent],
  providers: [AccessTokenService, LocalStorageService]
})
export class LoginRegisterModule { }
