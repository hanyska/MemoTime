import { Routes } from '@angular/router'
import { RegisterComponent } from './users/register/register.component'
import { LoginComponent } from './users/login/login.component';

export const PUBLIC_ROUTES: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
];
