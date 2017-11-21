import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes }  from '@angular/router';

import { PUBLIC_ROUTES } from './public.rotues'

import { RegisterComponent } from './users/register/register.component'

const APP_ROUTES: Routes = [
  { path: '', component: RegisterComponent, data: { title: 'Public Views' }, children: PUBLIC_ROUTES },

];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(
      APP_ROUTES,
      { enableTracing: false } // <-- debugging purposes only
    )
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule { }
