import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { RegisterComponent } from "./users/register/register.component";
import { UsersService } from "./users/services/users.service";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { LoginComponent  } from './users/login/login.component';
import { AppRoutingModule} from "./routing/app-routing.module";
import { HomeModule } from "./home/home.module";
import { HomepageComponent } from "./home/homepage/homepage.component";
import { NavComponent } from "./home/nav/nav.component";
import {Guard} from "./services/Guard";
import {SecureComponent} from "./Secure/secure/secure.component";
import {PublicComponent} from "./Public/public/public.component";
import { DashboardComponent } from './Secure/dashboard/dashboard.component';
import {DragulaModule} from "ng2-dragula";
import {ProjectsService} from "./tasks/services/projects.service";
import {TodoManagerComponent} from "./tasks/todo-manager/task-dashboard.component";
import {AccountComponent} from "./users/account/account.component";
import {ProfileComponent} from "./users/profile/profile.component";

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
    ProfileComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    HomeModule,
    DragulaModule
  ],
  providers: [ UsersService, Guard, ProjectsService],
  bootstrap: [ AppComponent ],
})
export class AppModule { }
