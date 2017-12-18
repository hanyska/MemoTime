import {Routes} from "@angular/router";
import {PUBLIC_ROUTES} from "./public.rotues";
import {Guard} from "../services/Guard";
import {SECURE_ROUTES} from "./secure.route";
import {SecureComponent} from "../components/secure/secure/secure.component";
import {PublicComponent} from "../components/public/public/public.component";

export const APP_ROUTES: Routes = [
  { path: '', component: SecureComponent, canActivate: [Guard], data: { title: 'Panel użytkownika' }, children: SECURE_ROUTES },
  { path: '', component: PublicComponent, data: { title: 'Strona Główna' }, children: PUBLIC_ROUTES },
];
