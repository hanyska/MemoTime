import {Routes} from "@angular/router";
import {DashboardComponent} from "../Secure/dashboard/dashboard.component";
import {RegisterComponent} from "../users/register/register.component";
import {TodoManagerComponent} from "../tasks/todo-manager/task-dashboard.component";
import {AccountComponent} from "../users/account/account.component";
import {ProfileComponent} from "../users/profile/profile.component";

export const SECURE_ROUTES: Routes = [
  { path: "", component: DashboardComponent,
    children: [
      { path: "", component: TodoManagerComponent},
      { path: "account", component: AccountComponent, children: [
              { path: "profile", component: ProfileComponent}
          ]},
      ],
  },
];
