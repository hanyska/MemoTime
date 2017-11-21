import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RegisterComponent } from "./users/register/register.component";
import {UsersService} from "./users/services/users.service";
import {FormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './users/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ UsersService ],
  bootstrap: [ AppComponent ],
})
export class AppModule { }
