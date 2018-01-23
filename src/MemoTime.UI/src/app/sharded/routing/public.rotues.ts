import { Routes } from '@angular/router'
import {RegisterComponent} from "../../modules/users/components/register/register.component";
import {HomepageComponent} from "../../modules/home/components/homepage/homepage.component";
import {LoginComponent} from "../../modules/users/components/login/login.component";

export const PUBLIC_ROUTES: Routes = [
  { path: 'home', component: HomepageComponent, data: { title: 'Strona Główna' }},
  { path: 'register', component: RegisterComponent, data: { title: 'Zarejestruj się' } },
  { path: 'login', component: LoginComponent, data: { title: 'Logowanie' } },
];
