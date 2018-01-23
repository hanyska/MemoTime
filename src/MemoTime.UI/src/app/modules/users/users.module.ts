import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RegisterComponent} from "./components/register/register.component";
import {UsersService} from "./users.service";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { LoginComponent } from './components/login/login.component';
import { AccountComponent } from './components/account/account.component';
import { ProfileComponent } from './components/profile/profile.component';
import { LogoutComponent } from './components/logout/logout.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    RegisterComponent, LogoutComponent
  ],
  providers: [  ],
  declarations: [ RegisterComponent, LoginComponent, AccountComponent, ProfileComponent, LogoutComponent ]
})
export class UsersModule { }
