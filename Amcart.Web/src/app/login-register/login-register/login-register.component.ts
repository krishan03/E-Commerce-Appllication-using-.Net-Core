import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AccessTokenService } from 'src/app/services/access-token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.css']
})
export class LoginRegisterComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private _accessToken: AccessTokenService,
    private ngRouter: Router) {
    this.loginForm = new FormGroup({
      userName: new FormControl(''),
      password: new FormControl(''),
    });
  }

  ngOnInit() {

  }

  onSubmit = () => {
    debugger;
    this._accessToken.GetToken(this.loginForm.value).subscribe((resp)=>{
      if(resp){
        this.ngRouter.navigate(['/home']);
      }
    });
  }

}
