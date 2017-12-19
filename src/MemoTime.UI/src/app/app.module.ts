import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { UsersService } from "./modules/users/users.service";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { LoginComponent  } from './modules/users/components/login/login.component';
import { AppRoutingModule} from "./sharded/routing/app-routing.module";
import { HomeModule } from "./modules/home/home.module";
import { HomepageComponent } from "./modules/home/components/homepage/homepage.component";
import { NavComponent } from "./modules/home/components/nav/nav.component";
import {Guard} from "./sharded/services/Guard";
import {SecureComponent} from "./sharded/components/secure/secure/secure.component";
import {PublicComponent} from "./sharded/components/public/public/public.component";
import { DashboardComponent } from './sharded/components/secure/dashboard/dashboard.component';
import {DragulaModule} from "ng2-dragula";
import {ProjectsService} from "./modules/tasks/projects.service";
import {AccountComponent} from "./modules/users/components/account/account.component";
import {ProfileComponent} from "./modules/users/components/profile/profile.component";
import { AuthService } from './sharded/services/auth.service';
import {RegisterComponent} from "./modules/users/components/register/register.component";
import {LogoutComponent} from "./modules/users/components/logout/logout.component";
import {TokenMiddleware} from "./sharded/services/token.middleware";
import {TodoManagerComponent} from "./modules/tasks/components/todo-manager/task-dashboard.component";
import {TaskFormComponent} from "./modules/tasks/components/task-form/task-form.component";
import {TasksService} from "./modules/tasks/tasks.service";
import {ProjectFormComponent} from "./modules/tasks/components/project-form/project-form.component";

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    HomepageComponent,
    NavComponent,
    SecureComponent,
    PublicComponent,
    DashboardComponent,
    TodoManagerComponent,
    AccountComponent, 
    ProfileComponent,
    LogoutComponent,
    TaskFormComponent,
    ProjectFormComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    HomeModule,
    DragulaModule,
  ],
  providers: [ UsersService, Guard, ProjectsService, AuthService,
      {
          provide: HTTP_INTERCEPTORS,
          useClass: TokenMiddleware,
          multi: true
      }, TasksService
  ],
  bootstrap: [ AppComponent ],
})
export class AppModule { }
