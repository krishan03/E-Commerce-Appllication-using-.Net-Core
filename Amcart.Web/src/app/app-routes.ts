import { AuthGuard } from "./auth-guard";
import { Routes } from "../../node_modules/@angular/router";
import { HomeComponent } from "./home/home.component";
import { ProfileComponent } from "./profile/profile.component";
import { LoginRegisterComponent } from "./login-register/login-register/login-register.component";
import { LoginCallbackComponent } from "./login-callback/login-callback.component";

export const routes: Routes = [
    {
        path:'callback', 
        component: LoginCallbackComponent, 
        pathMatch: 'full'
    },
    {
        path: '',
        component: HomeComponent,
        pathMatch: 'full'
    },
    {
        path:'profile', 
        component: ProfileComponent, 
        canActivate: [AuthGuard]
    }
];
