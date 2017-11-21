import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RegisterComponent} from "./register/register.component";
import {UsersService} from "./services/users.service";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { LoginComponent } from './login/login.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [
    RegisterComponent
  ],
  providers: [  ],
  declarations: [ RegisterComponent, LoginComponent ]
})
export class UsersModule { }
