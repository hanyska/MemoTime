import {Routes} from "@angular/router";
import {HomepageComponent} from "../home/homepage/homepage.component";
import {PUBLIC_ROUTES} from "./public.rotues";
import {RegisterComponent} from "../users/register/register.component";
import {LoginComponent} from "../users/login/login.component";
import {Guard} from "../services/Guard";
import {SECURE_ROUTES} from "./secure.route";
import {SecureComponent} from "../Secure/secure/secure.component";
import {PublicComponent} from "../Public/public/public.component";

export const APP_ROUTES: Routes = [
  { path: '', component: SecureComponent, canActivate: [Guard], data: { title: 'Secure Views' }, children: SECURE_ROUTES },
  { path: '', component: PublicComponent, data: { title: 'Public Views' }, children: PUBLIC_ROUTES },
];
