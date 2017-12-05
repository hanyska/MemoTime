import { Routes } from '@angular/router'
import { RegisterComponent } from "../users/register/register.component";
import { LoginComponent } from "../users/login/login.component";
import {HomepageComponent} from "../home/homepage/homepage.component";

export const PUBLIC_ROUTES: Routes = [
  { path: "", component: HomepageComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
];
