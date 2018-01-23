import { Component, OnInit } from '@angular/core';
import {UsersService} from "../../users.service";
import {AuthService} from "../../../../sharded/services/auth.service";
import { Router} from "@angular/router";
import {AuthToken} from "../../../../sharded/models/AuthToken";

@Component({
    template: 'Zostałeś wylogowany',
})
export class LogoutComponent implements OnInit {
  constructor(private authService: AuthService,
              private usersService: UsersService,
              private router: Router) { }

  ngOnInit() {
    this.usersService.logoutUser().subscribe(
        res => {
          this.authService.removeToken()
          setTimeout((router: Router) => {
                this.router.navigate(['']);
            }, 3000);
        })
  }
}
