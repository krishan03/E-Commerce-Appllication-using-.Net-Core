import { AuthGuard } from "./auth-guard";
import { Routes } from "../../node_modules/@angular/router";
import { HomeComponent } from "./home/home.component";
import { ProfileComponent } from "./profile/profile.component";
import { LoginRegisterComponent } from "./login-register/login-register/login-register.component";

export const routes: Routes = [
    {
        path:'', 
        component: LoginRegisterComponent, 
        pathMatch: 'full'
    },
    {
        path:'signin', 
        component: LoginRegisterComponent, 
        pathMatch: 'full'
    },
    {
        path:'home', 
        component: HomeComponent, 
        pathMatch: 'full',
        canActivate: [AuthGuard]
    },
    {
        path:'profile', 
        component: ProfileComponent, 
        // canActivate: [AuthGuard]
    },
    {
        path: '**',
        redirectTo: ''
    }
];