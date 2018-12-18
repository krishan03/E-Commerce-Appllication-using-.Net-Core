import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() { }

  login() {
    this.authService.redirectToLogin();
  }

  logout() {
    this.authService.redirectToLogout();
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }

  navigateToProfile() {
    this.router.navigate(['profile']);
  }
}
