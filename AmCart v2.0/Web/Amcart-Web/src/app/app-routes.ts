import { Routes } from "../../node_modules/@angular/router";
import { HomeComponent } from "./home/home.component";
import { ProfileComponent } from "./customer/profile/profile.component";
import { LoginCallbackComponent } from "./auth/login-callback/login-callback.component";
import { LogoutCallbackComponent } from "./auth/logout-callback/logout-callback.component";
import { MainComponent } from "./main/main.component";
import { AuthGuard } from "./core/auth.guard";
import { SilentCallbackComponent } from "./auth/silent-callback/silent-callback.component";

export const ApplicationRoutes: Routes = [
    {
        path: '',
        component: MainComponent,
        children: [
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
        ]
    },
    {
        path: 'login-callback',
        component: LoginCallbackComponent,
        pathMatch: 'full'
    },
    {
        path: 'logout-callback',
        component: LogoutCallbackComponent,
        pathMatch: 'full'
    },
    {
        path: 'silent-callback',
        component: SilentCallbackComponent,
        pathMatch: 'full'
    }
];