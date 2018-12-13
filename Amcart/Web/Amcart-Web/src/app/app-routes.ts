//import { AuthGuard } from "./auth-guard";
import { Routes } from "../../node_modules/@angular/router";
import { HomeComponent } from "./home/home.component";
import { ProfileComponent } from "./customer/profile/profile.component";

export const ApplicationRoutes: Routes = [
    {
        path: '',
        component: HomeComponent,
        pathMatch: 'full'
    },
    {
        path:'profile', 
        component: ProfileComponent, 
        //canActivate: [AuthGuard]
    }
];
