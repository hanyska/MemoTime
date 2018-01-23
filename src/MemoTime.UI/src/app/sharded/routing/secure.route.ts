import {Routes} from "@angular/router";
import {DashboardComponent} from "../components/secure/dashboard/dashboard.component";
import {TodoManagerComponent} from "../../modules/tasks/components/todo-manager/task-dashboard.component";
import {AccountComponent} from "../../modules/users/components/account/account.component";
import {ProfileComponent} from "../../modules/users/components/profile/profile.component";
import {LogoutComponent} from "../../modules/users/components/logout/logout.component";
import {Guard} from "../services/Guard";

export const SECURE_ROUTES: Routes = [
  { path: "", canActivateChild: [Guard], component: DashboardComponent,
    children: [
      { path: "", component: TodoManagerComponent, data: { title: 'Manager Zadań' }},
      { path: "logout", component: LogoutComponent, data: {title: 'Wyloguj'}},
      { path: "account", component: AccountComponent, data: { title: 'Konto użytkownika' }, children: [
              { path: "profile", component: ProfileComponent}
          ]},
      ],
  },
];
